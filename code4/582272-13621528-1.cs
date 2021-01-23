    private string path;
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                }
                
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                MessageBox.Show(path);
            }
