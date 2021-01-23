        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;
            if (!File.Exists(filePath))
            {
                MessageBox.Show(string.Format("Could not find file {0}", filePath));
            }
            elseif (Path.GetExtension(filename).ToLower()) != ".txt"))
            {
                MessageBox.Show(string.Format("File at {0} is not a text file", filePath));
            }
            else
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    textbox2.Text = reader.ReadAll();
                }
            }
        }
