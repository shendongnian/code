            var arguments = new Dictionary<string, string>();
            foreach (var item in Environment.GetCommandLineArgs())
            {
                try
                {
                    var parts = item.Split('=');
                    arguments.Add(parts[0], parts[1]);
                }
                catch (Exception ex)
                {
                    // your error handling here....
                }
