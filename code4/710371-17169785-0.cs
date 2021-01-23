    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
            //just write number of Points you require on X-Axis of Y-Axis
            //This will also define how big the Panel gets
            int PointsX = 10;
            int PointsY = 5;
            private void InitializeComponent()
            {
                this.panel1 = new System.Windows.Forms.Panel();
                this.SuspendLayout();
                // 
                // panel1
                // 
                //this.panel1.Dock = DockStyle.Fill;
                this.panel1.Location = new System.Drawing.Point(1, 1);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size((PointsX*20), (PointsY*20));//Was 300,300
                this.panel1.TabIndex = 0;
                this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.mPictureBoxPaint_Paint);
                // 
                // Form2
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.AutoScroll = true;
                this.ClientSize = new System.Drawing.Size(400, 300);
                this.Controls.Add(this.panel1);
                this.Name = "Form2";
                this.Text = "Form2";
                this.ResumeLayout(false);
    
            }
    
            private void mPictureBoxPaint_Paint(object sender, PaintEventArgs e)
            {
    
                Pen blackPen = new Pen(Brushes.Black);
                blackPen.Width = 1.0F;
                blackPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
    
                for (int i = 0; i < PointsX; i++)
                {
                    for (int j = 0; j < PointsY; j++) 
                    {
                        e.Graphics.DrawRectangle(blackPen,
                            new Rectangle(i*20, j*20, 2, 2));
                    }
                }
    
    
                blackPen.Dispose();
            }
            private System.Windows.Forms.Panel panel1;
    
    
            }
        }
