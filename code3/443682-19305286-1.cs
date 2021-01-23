    private void DgvInit(){
    	SuspendLayout();
    	dataGridView1.Dispose();
    	Controls.Remove(dataGridView1);
    	dataGridView1=new DataGridView();
    	((ISupportInitialize)(dataGridView1)).BeginInit();
    	dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    	dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    	dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    	dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
    	dataGridView1.Location = new Point(12, 28);
    	dataGridView1.Name = "dataGridView1";
    	dataGridView1.Size = new Size(658, 422);
    	dataGridView1.TabIndex = 0;
    	Controls.Add(dataGridView1);
    	((ISupportInitialize)(dataGridView1)).EndInit();
    	ResumeLayout(true);
    }
