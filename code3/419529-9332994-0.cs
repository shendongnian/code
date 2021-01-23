    DataGridView dataGridView1 = new System.Windows.Forms.DataGridView();
    DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
    ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
    // 
    // dataGridView1
    // 
    dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
    Column1});
    dataGridView1.Location = new System.Drawing.Point(38, 58);
    dataGridView1.Name = "dataGridView1";
    dataGridView1.Size = new System.Drawing.Size(240, 150);
    dataGridView1.TabIndex = 0;
    // 
    // Column1
    // 
    Column1.HeaderText = "Column1";
    Column1.Name = "Column1";
    Column1.DataPropertyName = "Time";
    this.Controls.Add(dataGridView1);
    ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
    
    List<TimeSpanItem> list = new List<TimeSpanItem>();
    list.Add(new TimeSpanItem() { Time = DateTime.Now.TimeOfDay });
    
    dataGridView1.DataSource = list;
