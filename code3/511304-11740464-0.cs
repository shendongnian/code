    result = Path.GetFileName(file);
    String[] f = File.ReadAllLines(file);  // major change here... 
                                           //  now f is an array containing all lines 
                                           //  instead of a stream reader
    using(var fw = new StreamWriter(result, false))
    {
        int counter = f.Length; // you aren't using counter anywhere, so I don't know if 
                                //  it is needed, but now you can just access the `Length`  
                                //  property of the array and get the length without a 
                                //  counter
        int spaceAtEnd = 0;
        // Read the file and display it line by line.
        foreach (var item in f)
        {
            var line = item;
            if (line.EndsWith(" "))
            {
                spaceAtEnd++;
                line = line.Substring(0, line.Length - 1);
            }
            fw.WriteLine(line);
            fw.Flush(); 
        }
    }
    MessageBox.Show("File Name : " + result);
    MessageBox.Show("Total Space at end : " + spaceAtEnd.ToString());
