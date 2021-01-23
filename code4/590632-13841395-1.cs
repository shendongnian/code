            string str = "8\'5\"";
            //one row version
            str = str.Replace('\'', '-').Insert(0, "\"");
            Console.WriteLine(str);            
            //multi row version, just for understanding
            str = "8\'5\"";            
            str = str.Replace('\'', '-');            
            str = str.Insert(0, "\"");
