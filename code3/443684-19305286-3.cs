    private void DgvInit(){
        var dgvs=dataGridView1.Size;
        SuspendLayout();
        dis:try{
            dataGridView1.Dispose();
        } catch{goto dis;}
        Controls.Remove(dataGridView1);
        dataGridView1=new DataGridView();
        ((ISupportInitialize)(dataGridView1)).BeginInit();
        dataGridView1.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        dataGridView1.Location = new Point(12, 28);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size=dgvs;
        dataGridView1.TabIndex = 0;
        Controls.Add(dataGridView1);
        ((ISupportInitialize)(dataGridView1)).EndInit();
        ResumeLayout(true);
    }
