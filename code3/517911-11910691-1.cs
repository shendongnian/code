    namespace ReusingUserControlsSample
    {
        partial class MyUserControlWithButtons
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
            #region Component Designer generated code
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.btnLetterA = new System.Windows.Forms.Button();
                this.btnLetterB = new System.Windows.Forms.Button();
                this.btnLetterC = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // btnLetterA
                // 
                this.btnLetterA.Location = new System.Drawing.Point(3, 3);
                this.btnLetterA.Name = "btnLetterA";
                this.btnLetterA.Size = new System.Drawing.Size(66, 21);
                this.btnLetterA.TabIndex = 0;
                this.btnLetterA.Text = "The \"A\"";
                this.btnLetterA.UseVisualStyleBackColor = true;
                this.btnLetterA.Click += new System.EventHandler(this.btnLetterA_Click);
                // 
                // btnLetterB
                // 
                this.btnLetterB.Location = new System.Drawing.Point(66, 30);
                this.btnLetterB.Name = "btnLetterB";
                this.btnLetterB.Size = new System.Drawing.Size(66, 21);
                this.btnLetterB.TabIndex = 0;
                this.btnLetterB.Text = "The \"B\"";
                this.btnLetterB.UseVisualStyleBackColor = true;
                this.btnLetterB.Click += new System.EventHandler(this.btnLetterB_Click);
                // 
                // btnLetterC
                // 
                this.btnLetterC.Location = new System.Drawing.Point(3, 57);
                this.btnLetterC.Name = "btnLetterC";
                this.btnLetterC.Size = new System.Drawing.Size(66, 21);
                this.btnLetterC.TabIndex = 0;
                this.btnLetterC.Text = "The \"C\"";
                this.btnLetterC.UseVisualStyleBackColor = true;
                this.btnLetterC.Click += new System.EventHandler(this.btnLetterC_Click);
                // 
                // MyUserControlWithButtons
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.AutoSize = true;
                this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                this.Controls.Add(this.btnLetterC);
                this.Controls.Add(this.btnLetterB);
                this.Controls.Add(this.btnLetterA);
                this.Name = "MyUserControlWithButtons";
                this.Size = new System.Drawing.Size(135, 81);
                this.ResumeLayout(false);
            }
            #endregion
            private System.Windows.Forms.Button btnLetterA;
            private System.Windows.Forms.Button btnLetterB;
            private System.Windows.Forms.Button btnLetterC;
        }
    }
