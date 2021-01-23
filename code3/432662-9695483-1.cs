        private static void so_JeffBorden()
        {
            string path = @"C:\sandbox\SSISHackAndSlash2008\SSISHackAndSlash2008\so_JeffBorden.dtsx";
            ListDictionary variables;
            variables = new ListDictionary()
            {
                {"ClientId", 100},
                {"FileName", @"C:\ssisdata\so\so_matt2.csv"}
            };
            string pkgLocation;
            Package pkg;
            Application app;
            DTSExecResult pkgResults;
            Variables vars;
            pkgLocation = path;
            app = new Application();
            using (pkg = app.LoadPackage(pkgLocation, null))
            {
                vars = pkg.Variables;
                foreach (DictionaryEntry variable in variables)
                {
                    vars[variable.Key].Value = variable.Value;
                }
                pkgResults = pkg.Execute(null, vars, null, null, null);
                //pkgResults = pkg.Execute();
                for (int i = 0; i < pkg.Errors.Count; i++)
                    Console.WriteLine(pkg.Errors[i].Description);
                Console.WriteLine(pkgResults.ToString());
                app.SaveToXml(@"C:\sandbox\SSISHackAndSlash2008\SSISHackAndSlash2008\so_JeffBorden2.dtsx", pkg, null);
            }
        }
