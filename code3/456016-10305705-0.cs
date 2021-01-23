    namespace MouseForm
    {
        partial class Form1
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
    
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            #region Windows Form Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
                this.ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
                this.timer1 = new System.Windows.Forms.Timer(this.components);
                this.SuspendLayout();
                // 
                // shapeContainer1
                // 
                this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
                this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
                this.shapeContainer1.Name = "shapeContainer1";
                this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
                this.ovalShape1});
                this.shapeContainer1.Size = new System.Drawing.Size(74, 74);
                this.shapeContainer1.TabIndex = 0;
                this.shapeContainer1.TabStop = false;
                // 
                // ovalShape1
                // 
                this.ovalShape1.BorderColor = System.Drawing.Color.Red;
                this.ovalShape1.BorderWidth = 3;
                this.ovalShape1.FillColor = System.Drawing.SystemColors.Control;
                this.ovalShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
                this.ovalShape1.Location = new System.Drawing.Point(2, 2);
                this.ovalShape1.Name = "ovalShape1";
                this.ovalShape1.Size = new System.Drawing.Size(70, 70);
                // 
                // timer1
                // 
                this.timer1.Enabled = true;
                this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(74, 74);
                this.ControlBox = false;
                this.Controls.Add(this.shapeContainer1);
                this.Enabled = false;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Name = "Form1";
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
                this.Text = "Form1";
                this.TopMost = true;
                this.TransparencyKey = System.Drawing.SystemColors.Control;
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
            private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape1;
            private System.Windows.Forms.Timer timer1;
        }
    }
