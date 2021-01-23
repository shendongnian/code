            string query = "hi there";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() == query)
                {
                    TextWriter tw = new StreamWriter("file.txt");
                    tw.WriteLine("Success!");
                    tw.Close();
                }
            }
