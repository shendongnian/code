    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework.Graphics;
    
    namespace ClickThroughXNA
    {
        public partial class Form1 : Form
        {
            // Directx graphics device
            GraphicsDevice dev = null;        
            BasicEffect effect = null;     
    
            // Wheel vertexes
            VertexPositionColor[] v = new VertexPositionColor[100];
    
            // Wheel rotation
            float rot = 0;
    
            public Form1()
            {
                InitializeComponent();
    
                StartPosition = FormStartPosition.CenterScreen;   
                Size = new System.Drawing.Size(500, 500);
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;  // no borders
    
                TopMost = true;        // make the form allways on top                     
                Visible = true;        // Important! if this isn't set, then the form is not shown at all
                
                // Set the form click-through
                int initialStyle = GetWindowLong(this.Handle, -20);
                SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
    
                // Create device presentation parameters
                PresentationParameters p = new PresentationParameters();
                p.IsFullScreen = false;
                p.DeviceWindowHandle = this.Handle;
                p.BackBufferFormat = SurfaceFormat.Vector4;
                p.PresentationInterval = PresentInterval.One;
                
                // Create XNA graphics device
                dev = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, p);
                            
                // Init basic effect
                effect = new BasicEffect(dev);
    
                // Extend aero glass style on form init
                OnResize(null);
            }
    
    
            protected override void OnResize(EventArgs e)
            {
                int[] margins = new int[] { 0, 0, Width, Height };
             
                // Extend aero glass style to whole form
                DwmExtendFrameIntoClientArea(this.Handle, ref margins);  
            }
            
    
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                // do nothing here to stop window normal background painting
            }
                    
    
            protected override void OnPaint(PaintEventArgs e)
            {                
                // Clear device with fully transparent black
                dev.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0.0f));
    
                // Rotate wheel a bit
                rot+=0.1f;
                    
                // Make the wheel vertexes and colors for vertexes
                for (int i = 0; i < v.Length; i++)
                {                    
                    if (i % 3 == 1)
                        v[i].Position = new Microsoft.Xna.Framework.Vector3((float)Math.Sin((i + rot) * (Math.PI * 2f / (float)v.Length)), (float)Math.Cos((i + rot) * (Math.PI * 2f / (float)v.Length)), 0);
                    else if (i % 3 == 2)
                        v[i].Position = new Microsoft.Xna.Framework.Vector3((float)Math.Sin((i + 2 + rot) * (Math.PI * 2f / (float)v.Length)), (float)Math.Cos((i + 2 + rot) * (Math.PI * 2f / (float)v.Length)), 0);
    
                    v[i].Color = new Microsoft.Xna.Framework.Color(1 - (i / (float)v.Length), i / (float)v.Length, 0, i / (float)v.Length);
                }
    
                // Enable position colored vertex rendering
                effect.VertexColorEnabled = true;
                foreach (EffectPass pass in effect.CurrentTechnique.Passes) pass.Apply();
                
                // Draw the primitives (the wheel)
                dev.DrawUserPrimitives(PrimitiveType.TriangleList, v, 0, v.Length / 3, VertexPositionColor.VertexDeclaration);
    
                // Present the device contents into form
                dev.Present();
    
                // Redraw immediatily
                Invalidate();            
            }
            
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    
            [DllImport("user32.dll")]
            static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    
            [DllImport("dwmapi.dll")]
            static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref int[] pMargins);
    
        }
    }
