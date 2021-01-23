    this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.comboBox1.FormattingEnabled = true;
                this.comboBox1.Items.AddRange(new object[] {
                "S",
                "M",
                "L",
                "XL",
                "XXL",
                "XXXL",
                "XXXXL"});
                this.comboBox1.Location = new System.Drawing.Point(32, 55);
                this.comboBox1.Name = "comboBox1";
                this.comboBox1.Size = new System.Drawing.Size(188, 21);
                this.comboBox1.TabIndex = 0;
                this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
                // 
                // listBox1
                // 
                this.listBox1.FormattingEnabled = true;
                this.listBox1.Items.AddRange(new object[] {
                "Levi\'s",
                "Pepe Jeans",
                "Wrangler",
                "Denim",
                "Nature"});
                this.listBox1.Location = new System.Drawing.Point(261, 55);
                this.listBox1.Name = "listBox1";
                this.listBox1.Size = new System.Drawing.Size(255, 95);
                this.listBox1.TabIndex = 1;
                this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
