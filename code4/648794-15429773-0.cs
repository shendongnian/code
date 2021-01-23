     private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
                {
                    //after you've filled your ds, on event above try something like this
                    try
                    {
        
                        da.Update(ds);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
