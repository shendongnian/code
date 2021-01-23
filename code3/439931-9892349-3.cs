    private void push()
    {
        //write to the file for output control (for test only)
        using (StreamWriter str = new StreamWriter("C:\\temp\\butch.txt", true))
        {
            str.WriteLine("GO: " + line); 
        }
        
        butch.Add(line);
        line = "";
    }
