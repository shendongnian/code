      OpenFileDialog f = new OpenFileDialog();
        if (f.ShowDialog() ==DialogResult.OK)
        {
            listBox1.Items.Clear();
            List<string> lines = new List<string>();
            using (StreamReader r = new StreamReader(f.OpenFile()))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
            }
        }
