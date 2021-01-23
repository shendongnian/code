    namespace ReusingUserControlsSample
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
                this.mytextbox = new System.Windows.Forms.TextBox();
                this.mykeyboard = new ReusingUserControlsSample.MyUserControlWithButtons();
                this.SuspendLayout();
                // 
                // mytextbox
                // 
                this.mytextbox.Location = new System.Drawing.Point(84, 38);
                this.mytextbox.Name = "mytextbox";
                this.mytextbox.Size = new System.Drawing.Size(100, 20);
                this.mytextbox.TabIndex = 0;
                // 
                // mykeyboard
                // 
                this.mykeyboard.AutoSize = true;
                this.mykeyboard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                this.mykeyboard.Location = new System.Drawing.Point(66, 122);
                this.mykeyboard.Name = "mykeyboard";
                this.mykeyboard.Size = new System.Drawing.Size(135, 81);
                this.mykeyboard.TabIndex = 1;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 264);
                this.Controls.Add(this.mykeyboard);
                this.Controls.Add(this.mytextbox);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            #endregion
            private System.Windows.Forms.TextBox mytextbox;
            private MyUserControlWithButtons mykeyboard;
        }
    }
