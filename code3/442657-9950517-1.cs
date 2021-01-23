    if(openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        if((myStream = openFileDialog1.OpenFile())!= null)
        {
            using (var reader = new StreamReader(myStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // if it's one num per line, you can use Parse() or TryParse()
                    var num = int.Parse(line);
                    // otherwise, you can use something like string.Split() or RegEx...
                }
            }
        }
    }
