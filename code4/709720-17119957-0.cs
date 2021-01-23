    using(var reader = new StreamReader(@"c:\test.txt")){
        while((line = reader.ReadLine()) != null)
        {
            ListBox.Items.Add(line);
        }
    }
