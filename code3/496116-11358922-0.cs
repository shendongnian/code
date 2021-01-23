            // new list 
            var l = new List<string>();
            // original data
            var s = "[{\"name\":\"FirstName\",\"value\":\"Raja\"},{\"name\":\"MiddleName\",\"value\":\"Raja \"},{\"name\":\"LastName\",\"value\":\"KUMAR\"}]";
            // clean up and split in larger parts
            var d = s.Substring(1, s.Length - 2).Replace("\\", "").Replace("\"", "").Replace("}", "").Split('{');
            // Split in final entries and add to list
            var sb = new char[2] { ',', ':' };
            foreach (var r in d) { l.AddRange(r.Split(sb, StringSplitOptions.RemoveEmptyEntries)); 
