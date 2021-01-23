    private void Form1_Load(object sender, EventArgs e)
        {
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        dataGridView1.ColumnHeadersHeight = 50;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
        
        // Here we attach an event handler to the cell painting event
        dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
        }
            void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                // check that we are in a header cell!
                if (e.RowIndex == -1 && e.ColumnIndex >= 0)
                {
                    e.PaintBackground(e.ClipBounds, true);
                    Rectangle rect = this.dataGridView1.GetColumnDisplayRectangle(e.ColumnIndex, true);
                    Size titleSize = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font);
                    if (this.dataGridView1.ColumnHeadersHeight < titleSize.Width)
                    {
                        this.dataGridView1.ColumnHeadersHeight = titleSize.Width;
                    }
            
                    e.Graphics.TranslateTransform(0, titleSize.Width);
                    e.Graphics.RotateTransform(-90.0F);
            
                    // This is the key line for bottom alignment - we adjust the PointF based on the 
                    // ColumnHeadersHeight minus the current text width. ColumnHeadersHeight is the
                    // maximum of all the columns since we paint cells twice - though this fact
                    // may not be true in all usages!   
                    e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y - (dataGridView1.ColumnHeadersHeight - titleSize.Width) , rect.X));
            
                    // The old line for comparison
                    //e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y, rect.X));
            
            
                    e.Graphics.RotateTransform(90.0F);
                    e.Graphics.TranslateTransform(0, -titleSize.Width);
                    e.Handled = true;
                }
            }
        
        
