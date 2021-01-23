            // TODO: check for listBox1.Text to be blank or non-file
            if (comboBox1.Text == "Select File Destination")
            {
                MessageBox.Show("Please Select A Destination Folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sourceFile = Path.Combine(Environment.SpecialFolder.UserProfile, "Downloads", listBox1.Text;
            string destinationFile = Path.Combine(Environment.SpecialFolder.MyDocuments, "iracing", "setups", comboBox1.Text;
            File.Move(sourceFile, destinationFile);
        }
        catch { }
