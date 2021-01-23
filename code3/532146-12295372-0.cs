        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private bool sel1 = true; 
        private void Form1_Load(object sender, EventArgs e)
        {
            //
            this.label1 = new System.Windows.Forms.Label();
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "One";
            this.label2 = new System.Windows.Forms.Label();
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 44);
            this.label2.Name = "label1";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Two";
            groupBox1.Controls.Add(label1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            sel1 = !sel1;
            if (sel1)
                groupBox1.Controls.Add(label1);
            else
                groupBox1.Controls.Add(label2);
        }
