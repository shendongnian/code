    this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
    this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
    this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
    this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
    this.dataGridView1.Name = "dataGridView1";
    this.dataGridView1.Size = new System.Drawing.Size(405, 150);
    this.dataGridView1.TabIndex = 1;
    this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
