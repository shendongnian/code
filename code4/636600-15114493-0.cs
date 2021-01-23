    string pass4 = "pass4";
    foreach (string pass in new string[] { "pass1", "pass2", "pass3", pass4 })
    {
        pass4="pass5 - oops";
        x = pass; //etc
    }
