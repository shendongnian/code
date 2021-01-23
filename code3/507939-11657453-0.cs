        Server server = new Server("XXX");
        Database database = new Database();
        database = server.Databases["YYY"];
        Table table = database.Tables["ZZZ", @"PPP"];
        StringCollection result = table.Script();
        var script = "";
        foreach (var line in result) {
            script += line;
        }
        
        System.IO.StreamWriter fs = System.IO.File.CreateText(@"QQQ");
        fs.Write(script);
        fs.Close();
