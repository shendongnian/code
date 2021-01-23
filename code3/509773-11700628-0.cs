      private void button1_Click(object sender, EventArgs e)
            {
                string imageLink= textBox1.Text;
               try
                        {
                            int i;
                            i = dataGridView1.Rows.Add(new DataGridViewRow());
                            dataGridView1.Rows[i].Cells["Column1"].Value = imageLink;
                            
    
                        }
                        catch (Exception ex)
                        {
                           
                            MessageBox.Show("error");
                        }
            }
    
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
    
                string img = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
    
    
                pictureBox1.ImageLocation = img;
            }
