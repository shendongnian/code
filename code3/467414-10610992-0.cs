        public void addOpenProgramsToDataGrid()
        {
            dataGridView1.ColumnCount = 3;
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.HeaderText = "Selected";
                column.Name = "Selected";
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.White;
            }
            dataGridView1.Columns.Insert(0, column); // This is to be a checkbox column
            dataGridView1.Columns[0].HeaderText = "X";
            dataGridView1.Columns[1].HeaderText = "Process Name:";
            dataGridView1.Columns[2].HeaderText = "Window Title";
            dataGridView1.Columns[3].HeaderText = "Open File or URL";
            dataGridView1.RowCount = opList.Count;
            //opList.RemoveRange(0, opList.Count);
            for (int a = 0; a < opList.Count; a++)
            {
                openProgram tempProgram = new openProgram();
                tempProgram = opList[a];
                dataGridView1.Rows[a].Cells[0].Value = true;
                
                dataGridView1.Rows[a].Cells[1].Value = tempProgram.processName;
                dataGridView1.Rows[a].Cells[2].Value = tempProgram.windowTitle;
                dataGridView1.Rows[a].Cells[3].Value = tempProgram.openFileOrURL;
            }
            selectAllCheckBox.Checked = true;
        }
