    private void menuFileOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            
    
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
    
    
                MessageBox.Show("TEST", "Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                try
                {
                    MessageBox.Show("TEST", "Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    motelManager.ReadFromFile(this, file); // Smart lösning!!
    
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Error message", "Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
