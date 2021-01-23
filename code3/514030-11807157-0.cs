     private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
            {
                try
                {
                    if (sender is GridImageCellElement)
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
