    //load the input file
    //open with read and sharing
    using (FileStream fsInput = new FileStream("input.txt", 
        FileMode.Open, FileAccess.Read, FileShare.Read)) 
    {
        //use streamreader to search for start
        var srInput = new StreamReader(fsInput);
        string searchString = "two";
        string cSearch = null;
        bool found = false;
        while ((cSearch = srInput.ReadLine()) != null)
        {
            if (cSearch.StartsWith(searchString, StringComparison.CurrentCultureIgnoreCase)
            {
                found = true;
                break;
            }
        }
        if (!found)
            throw new Exception("Searched string not found.");
        //we have the data, write to a new file
        using (StreamWriter sw = new StreamWriter(
            new FileStream("out.txt", FileMode.OpenOrCreate, //create or overwrite
                FileAccess.Write, FileShare.None))) // write only, no sharing
        {
            //write the line that we found in the search
            sw.WriteLine(cSearch);
            string cline = null;
            while ((cline = srInput.ReadLine()) != null)
                sw.WriteLine(cline);
        }
    }
    //both files are closed and complete
