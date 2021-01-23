    /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                this.button1 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                
                //  this.button1.Image = new Bitmap(@"C:\images\dance.gif");
    
                // if you import the local resource 
                this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
                this.button1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
                this.button1.Location = new System.Drawing.Point(109, 73);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(523, 437);
                this.button1.TabIndex = 1;
                this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.button1.UseVisualStyleBackColor = true;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(807, 640);
                this.Controls.Add(this.button1);
                this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Name = "Form1";
                this.Text = "Image In Button Control";
                this.ResumeLayout(false);
    
            }
