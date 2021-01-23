    using System;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
     
    namespace pixelcolor
    {
      /// <summary>
      /// Summary description for Form1.
      /// </summary>
      public class Form1 : System.Windows.Forms.Form
      {
     
     
        [DllImport("Gdi32.dll")]
        public static extern int GetPixel(
        System.IntPtr hdc,    // handle to DC
        int nXPos,  // x-coordinate of pixel
        int nYPos   // y-coordinate of pixel
        );
     
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr wnd);
     
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr dc);
     
     
        private System.Windows.Forms.Panel panel1;
        private System.Timers.Timer timer1;
     
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
     
        public Form1()
        {
          //
          // Required for Windows Form Designer support
          //
          InitializeComponent();
          this.SetStyle(ControlStyles.ResizeRedraw,true);
        }
     
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
          if( disposing )
          {
            if (components != null)
            {
              components.Dispose();
            }
          }
          base.Dispose( disposing );
        }
     
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.panel1 = new System.Windows.Forms.Panel();
          this.timer1 = new System.Timers.Timer();
          ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
          this.SuspendLayout();
          //
          // panel1
          //
          this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.panel1.Location = new System.Drawing.Point(216, 8);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(64, 56);
          this.panel1.TabIndex = 0;
          //
          // timer1
          //
          this.timer1.Enabled = true;
          this.timer1.SynchronizingObject = this;
          this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
          //
          // Form1
          //
          this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
          this.BackColor = System.Drawing.Color.White;
          this.ClientSize = new System.Drawing.Size(292, 273);
          this.Controls.Add(this.panel1);
          this.Name = "Form1";
          this.Text = "Form1";
          this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
          ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
          this.ResumeLayout(false);
     
        }
        #endregion
     
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          Application.Run(new Form1());
        }
     
        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
          Random r=new Random(1);
     
          for(int x=0;x<100;x++)
          {
            SolidBrush b=new SolidBrush(Color.FromArgb(r.Next(255),r.Next(255),r.Next(255)));
            e.Graphics.FillRectangle(b,r.Next(this.ClientSize.Width),r.Next(this.ClientSize.Height),r.Next(100),r.Next(100));
          }
        }
     
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
          Point p=Control.MousePosition;
          IntPtr dc=GetDC(IntPtr.Zero);
          this.panel1.BackColor=ColorTranslator.FromWin32(GetPixel(dc,p.X,p.Y));
          ReleaseDC(dc);
        }
      }
    }
     
