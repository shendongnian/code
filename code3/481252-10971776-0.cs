            var searchTerm = "SEARCH_TERM";
            var searchDirectory = new System.IO.DirectoryInfo(@"c:\Test\");
            var queryMatchingFiles =
                    from file in searchDirectory.GetFiles()
                    where file.Extension == ".txt"
                    let fileContent = System.IO.File.ReadAllText(file.FullName)
                    where fileContent.Contains(searchTerm)
                    select file.FullName;
            foreach (var fileName in queryMatchingFiles)
            {
                // Do something
                Console.WriteLine(fileName);
            }
