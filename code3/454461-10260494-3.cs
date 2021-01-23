        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;
            bool FileValid = ValidateFile(filePath);
            if (!IsFileValid)
            {
                MessageBox.Show(string.Format("File {0} does not exist or is not a text file", filePath));
            }
            else
            {
                textbox2.Text = GetFileContents(filePath);
            }
        }
        private bool IsFileValid(string filePath)
        {
            bool IsValid = true;
            if (!File.Exists(filePath))
            {
                IsValid = false;
            }
            else if (Path.GetExtension(filePath).ToLower() != ".txt")
            {
                IsValid = false;
            }
            return IsValid;
        }
        private string GetFileContents(string filePath)
        {
            string fileContent = string.Empty;
            using (StreamReader reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
            }
            return fileContent;
        }
