    using System;
    using System.IO;
    using System.Collections.Generic;
    
    
    List<string[]> some_function (string fn) {    //fn = "path/to/file"
        string line;
        List<string[]> rval = new List<string[]>();
        if (File.Exists(fn)) {
            StreamReader file = new StreamReader(fn);
            while ((line = file.ReadLine()) != null) {
                string[] value = line.Split(' ');
                rval.Add(value);
            }
            file.Close();
        }
        return rval;
    }
