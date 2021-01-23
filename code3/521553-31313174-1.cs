     string mystring = "foobar";
     Dictionary<string, string> stringsToReplace = new Dictionary<string,string>();
     stringsToReplace.Add("somestring", variable1);
     stringsToReplace.Add("somestring2", variable2);
     stringsToReplace.Add("somestring3", variable1);
     mystring = mystring.MultipleReplace(stringsToReplace);
