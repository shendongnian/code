    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using SharpDX.Direct3D;
    using SharpDX.Direct2D1;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    using SharpDX.DXGI;
    using SharpDX;
    using SharpDX.Windows;
    using System.Globalization;
    
    
    using SharpDX.DirectWrite;
    
    namespace dx11
    {
        
    
        public partial class Form1 : Form
        {
            private SharpDX.Direct3D10.Device _mDevice = null;
            WindowRenderTarget wndRender = null;
            SharpDX.Direct2D1.Factory fact = new SharpDX.Direct2D1.Factory(SharpDX.Direct2D1.FactoryType.SingleThreaded);
            SolidColorBrush scenebrush;
            RenderTargetProperties rndTargProperties;
            HwndRenderTargetProperties hwndProperties;
            SharpDX.Windows.RenderForm form = new RenderForm();
            RenderLoop.RenderCallback callback;
    
            public Form1()
            {
                InitializeComponent();
    
                SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
    
                form.Width = 600;
                form.Height = 600;
                test();
                callback = new RenderLoop.RenderCallback(Render);
                
                RenderLoop.Run(form, callback);                            
            }
    
            private void test()
            {
                    rndTargProperties = new RenderTargetProperties(new PixelFormat(Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied));
    
                    hwndProperties = new HwndRenderTargetProperties();
                    hwndProperties.Hwnd = form.Handle;
                    hwndProperties.PixelSize = new SharpDX.DrawingSize(form.ClientSize.Width, form.ClientSize.Height);
                    hwndProperties.PresentOptions = PresentOptions.None;
                    wndRender = new WindowRenderTarget(fact, rndTargProperties, hwndProperties);
                    scenebrush = new SolidColorBrush(wndRender, Colors.Red);
                   // scenebrush.Color = Colors.Cornsilk;
                    form.Show();
            }
    
            public void Render()
            {    
                
                wndRender.BeginDraw();
                wndRender.Clear(Colors.DarkBlue);
                wndRender.DrawRectangle(new SharpDX.RectangleF(10, 10, 50, 50), scenebrush, 2.00F);
                wndRender.Flush();
                   wndRender.EndDraw();
            }
    
        }
    }
