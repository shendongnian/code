    private void InitializeComponent()
     {
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.panel1 = new System.Windows.Forms.Panel();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.tableLayoutPanel1.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 3;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
          this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
          this.tableLayoutPanel1.Name = "tableLayoutPanel1";
          this.tableLayoutPanel1.RowCount = 1;
          this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 262);
          this.tableLayoutPanel1.TabIndex = 0;
          // 
          // panel1
          // 
          this.panel1.Controls.Add(this.button2);
          this.panel1.Controls.Add(this.button1);
          this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel1.Location = new System.Drawing.Point(45, 3);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(194, 256);
          this.panel1.TabIndex = 0;
          // 
          // button1
          // 
          this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.button1.Location = new System.Drawing.Point(3, 9);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(188, 23);
        this.button1.TabIndex = 0;
        this.button1.Text = "button1";
        this.button1.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.button2.Location = new System.Drawing.Point(3, 38);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(188, 23);
        this.button2.TabIndex = 0;
        this.button2.Text = "button1";
        this.button2.UseVisualStyleBackColor = true;
        // 
        // TestForm11
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 262);
        this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "TestForm11";
        this.Text = "TestForm11";
        this.tableLayoutPanel1.ResumeLayout(false);
        this.panel1.ResumeLayout(false);
        this.ResumeLayout(false);
    
    }
     
     #endregion
     
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
