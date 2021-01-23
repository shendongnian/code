            var directorypath = @"C:\";
            List<String> txtlist = Directory.GetFiles(directorypath, "*.txt").ToList();
 
            foreach (var textFile in txtlist)
            {
                using (StreamReader file = new StreamReader(textFile))
                {
                    var xmlFiles = file.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    var xmlFilesThatDontExsit = xmlFiles.Where(x => !System.IO.File.Exists(x));
                    //Do what you want with the files that dont exist
                }
            }
