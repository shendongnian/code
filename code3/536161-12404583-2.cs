    namespace panelvisible
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
                this.panel1 = new System.Windows.Forms.Panel();
                this.label1 = new System.Windows.Forms.Label();
                this.panel2 = new System.Windows.Forms.Panel();
                this.panel1.SuspendLayout();
                this.SuspendLayout();
                // 
                // panel1
                // 
                this.panel1.BackColor = System.Drawing.Color.Red;
                this.panel1.Controls.Add(this.panel2);
                this.panel1.Controls.Add(this.label1);
                this.panel1.Location = new System.Drawing.Point(101, 36);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(200, 100);
                this.panel1.TabIndex = 0;
                this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(49, 42);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(31, 13);
                this.label1.TabIndex = 0;
                this.label1.Text = "Hello";
                this.label1.Visible = false;
                // 
                // panel2
                // 
                this.panel2.BackColor = System.Drawing.Color.Gray;
                this.panel2.Location = new System.Drawing.Point(33, 70);
                this.panel2.Name = "panel2";
                this.panel2.Size = new System.Drawing.Size(118, 10);
                this.panel2.TabIndex = 1;
                this.panel2.Visible = false;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(494, 205);
                this.Controls.Add(this.panel1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.panel1.ResumeLayout(false);
                this.panel1.PerformLayout();
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private System.Windows.Forms.Panel panel1;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Panel panel2;
        }
    }
