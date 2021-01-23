        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.Filter = "Text Files|*.txt";
        openFileDialog1.Title = "Select a Text file";
        openFileDialog1.FileName = "";
        DialogResult result = openFileDialog1.ShowDialog();
        string file;
        if (result == DialogResult.OK)
        {
            file =  = default(string);
            if(!String.IsNullOfWhiteSpace(openFileDialog1.Filename))
                file = openFileDialog1.FileName;
            else
                retun; 
            string[] text = System.IO.File.ReadAllLines(file);
            foreach (string line in text)
            {
                try
                {
                    listBox2.Items.Add(line);
                 }
                catch(Exception e)
                   { MessageBox.Show(e.ToString());
                      return;
                    }
            }
            listBox2.Items.Add("");
        }
