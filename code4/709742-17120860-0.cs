    using (StreamReader sr = new StreamReader("Books.txt"))
    {
        while(true)
        {
            String line = sr.ReadLine();
            if(line==null)
              break;
            listBox1.Items.Add(line + "\n");
        }
    }
