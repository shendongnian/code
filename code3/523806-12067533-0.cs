    string name = textBox2.Text;
    string[] allFiles = System.IO.Directory.GetFiles("C:\\");//Change path to yours
    foreach (string file in allFiles)
        {
            if (file.Contains(name))
            {
                MessageBox.Show("Match Found : " + file);
            }
        }
