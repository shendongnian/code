    string html = // your html table goes here
    string[] lines = html.Split(new string[] { "^^~~~~~~~~~~^^" }, StringSplitOptions.None);
    // now your html table is divided into lines, which means rows
    
    // lines[0] = // the header
    // lines[1] = // row 1
    // lines[2] = // row 2
    // lines[3] = // row 3
    // ...
    // ...
    // line 1 is the header/column name
    string[] columns = lines[0].Split(new string[] { "||^^^^^^^^^||" }, StringSplitOptions.None);
    
    // columns[0] = // 1st column name
    // columns[1] = // 2nd column name
    // columns[2] = // 3rd column name
    // ...
    // ...
    
    for (int i = 1; i < lines.Length; i++)
    {
        string[] data = lines[i].Split(new string[] { "||^^^^^^^^^||" }, StringSplitOptions.None);
        // data[0] = // 1st data
        // data[1] = // 2nd data
        // data[2] = // 3rd data 
        // ...  
        // ...
    }
