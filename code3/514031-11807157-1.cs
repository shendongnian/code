     private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
            {
                try
                {
                    if (e.CellElement.ColumnInfo.HeaderText == "Picture") 
                    {
                        e.CellElement.Image = pictureBox1.Image;
                    }
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
