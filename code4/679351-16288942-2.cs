       try
        {
            textBox5.Text = openFile.FileName;
            using(TextWriter rlist_writer = new StreamWriter (openFile.FileName))
            {
                rlist_writer.WriteLine(rlist);
            }
        }
