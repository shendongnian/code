		Dictionary<string, object> d = new Dictionary<string, object>();
		d["s"] = "string";
		d["i"] = 5;
		d["db.null"] = DBNull.Value;
		Console.WriteLine(d.Read("i", 7));                        // 5
		Console.WriteLine(d.Read("s", "default string"));         // string
		Console.WriteLine(d.Read("db.null", "default string"));   // default string
		Console.WriteLine(d.Read("db.null", -1));                 // -1
		Console.WriteLine(d.Read<int>("i"));                      // 5
		Console.WriteLine(d.Read<string>("s"));                   // string
		Console.WriteLine(d.Read<int>("db.null"));                // 0
		Console.WriteLine(d.Read<string>("db.null") ?? "null");   // null
