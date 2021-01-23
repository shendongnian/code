        private void btnZoek_Click(object sender, EventArgs e)
        {
            try
            {
                int counter = 0;
                string line;
                List<String> LinesFound = new List<string>();
                // Read the file and display it line by line. 
                System.IO.StreamReader file = new System.IO.StreamReader("c:\\log.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(txtZoek.Text))
                    {
                        LinesFound.Add(line);
                    }
                }
                file.Close();
                foreach (string Line in LinesFound)
                {
                    txtResult.Text = txtResult.Text + Line + Environment.NewLine;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in btnZoek_Click");
            }
        }
