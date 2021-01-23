        private Panel box;
        private NumericUpDown ud1;
        private Button btn;        
        int rowNumber, rowIndex, colIndex;
        GridStyleInfo style;
        void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            rowNumber = this.gridGroupingControl1.Table.CurrentRecord.GetSourceIndex();
            rowIndex = this.gridGroupingControl1.TableControl.CurrentCell.RowIndex;
            colIndex = this.gridGroupingControl1.TableControl.CurrentCell.ColIndex;
            style = this.gridGroupingControl1.TableControl.GetViewStyleInfo(rowIndex,colIndex);
            box = new Panel(); // 
            ud1 = new NumericUpDown();
            ud1.Location = new Point(15, 15);
            ud1.Size = new Size(50, 10);
            ud1.BorderStyle = BorderStyle.FixedSingle;
            box.Controls.Add(ud1);
            box.BorderStyle = BorderStyle.None;
            btn = new Button();
            btn.Location = new Point(30, 50);
            btn.Size = new Size(30,20);
            btn.Text = "OK";
            btn.Click += new EventHandler(btn_Click);
            box.Controls.Add(btn);
            box.Location = this.gridGroupingControl1.TableControl.CurrentCell.Renderer.GetCellLayout(rowIndex, colIndex, style).ClientRectangle.Location;
            box.Size = new Size(80, 70);
            this.gridGroupingControl1.Controls.Add(box);
            box.Show();
            box.BringToFront();
        }
        void btn_Click(object sender, EventArgs e)
        {
            int numberOfRowstobeInserted = (int)ud1.Value;
            DataTable dt = (this.gridGroupingControl1.DataSource as DataView).Table;
            for (int count = 0; count < numberOfRowstobeInserted; count++)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                    dr[i] = 0; //default value
                dt.Rows.InsertAt(dr, rowNumber++);
            }
            box.Dispose();
        }
