    string dir = @"\\198.0.0.4\e$\Globus\LIVE\bnk.run\URA.BP\WEBOUT\";
    foreach (string fileName2 in Directory.GetFiles(dir)) {
        StreamReader st = new StreamReader(fileName2);
        while (!sr.EndOfStream)  {
    		string line = sr.ReadLine();
    		if (!String.IsNullOrEmpty(line)) {
    			string[] columns = line.Split(',');
    			if (columns.Length == 8) {
    				string prnout = columns[0];
    				string tinout = columns[1];
    				string amtout = columns[2];
    				string valdate = columns[3];
    				string paydate = columns[4];
    				string status = columns[5];
    				string branch = columns[6];
    				string reference = columns[7];
    			}
    		}
        }
    }
