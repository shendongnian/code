    private void WriteToFile() 
    { 
        // get an array of strings - you'll find out way :)
        string[] items = listBox1.Items.Cast<string>().ToArray();
        // this would also work with ReadAllLines()
        string[] items = File.ReadAllLines("Your original file");
        
        // path + filename prefix
        string fileNamePattern = "C:\\Users\\bbdnet0986\\Documents\\MyExpotedQADATA{0}.txt"; 
    
        // blocks of 100
        string[] buffer;
        for(int i = 0; i < items.Length; i += 100)
        {
            // slice the string array into 100 string blocks
            buffer = items.Slice(i, 100);
            // output the block of strings
            File.WriteAllLines(string.Format(fileNamePattern, i), buffer);
        }
    }
