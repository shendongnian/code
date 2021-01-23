            TextBox txtBox1 = null;           
            TableCell cell = new TableCell();
            GridView1.Rows[j].Cells.Add(cell);
                
            txtBox1.ID = "txtDemo";                    
            txtBox1.CssClass = "color";
            GridView1.Rows[j].Cells.Add(cell);
            GridView1.Rows[j].Cells[i + 1].Controls.Add(txtBox1);
