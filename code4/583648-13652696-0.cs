    using (StreamWriter writer = new StreamWriter("test.txt", true))
    {
        foreach (object item in listBox2.Items)
        {
            if (fileItems.Contains(item))
                // Do something, break, etc.
            else
                writer.WriteLine(item.ToString());
        }
    }
