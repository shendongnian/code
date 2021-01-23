    string[] input_file = (string[])(e.Data.GetData(DataFormats.FileDrop));
    string output_file = @"c:\scrubbed.txt";
    foreach (string file in input_file)
    {
        string[] lines = File.ReadAllLines(file);
    
        for (int i=0; i < lines.length; i++)
        {
    		string line = lines[i];
            if (line.StartsWith("NM1*QC"))
            {
    			string[] values = line.Split('*');
                values[1] = "Lastname";
                values[2] = "Firstname";
    			lines[i] = String.Join("*", values);
            }
        }
    
        File.WriteAllLines(output_file, lines);
    }
     
