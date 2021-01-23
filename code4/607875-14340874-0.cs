        private void button1_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            List<string> fileNames = new List<string>();
            foreach (string file in Directory.GetFiles("C:\\Users\\John\\Desktop\\Sample")){
                if (Path.GetFileName(file).Contains(txtSearch.Text)){
                    txtOutput.Text += txtOutput.Text + file + ", ";
                    fileNames.Add(file);
                }
            }
        }
