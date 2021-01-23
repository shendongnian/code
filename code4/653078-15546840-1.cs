       public void DirSearch(string root)
       {
               foreach (string file in Directory.EnumerateFiles(root, "*.cs"))
               {
                        string contents = File.ReadAllText(file);
                        // Write to your outputfile once you've happened what you want in your header.
               }
               foreach (string d in Directory.GetDirectories(root))
               {
                   DirSearch(d);
               }
       }
