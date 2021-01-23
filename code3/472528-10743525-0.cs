    private void SaveToRootFolder_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Test.txt";
            if (App.IsAdmin)
                DoSaveFile(textBox1.Text, textBox2.Text, fileName);
            else
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("Text1", textBox1.Text);
                parameters.Add("Text2", textBox2.Text);
                parameters.Add("FileName", fileName);
                string result = Program.ElevatedExecute(parameters);
                if (!string.IsNullOrEmpty(result))
                    MessageBox.Show(result);
            }
        }
