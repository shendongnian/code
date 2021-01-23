    string files = "C:\Hello; C:\Hi; D:\Goodmorning; D:\Goodafternoon; E:\Goodevening";
                //Get each path and remove whitespaces
                string[] paths = files.Split(new[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //Use xmlLoc for adding \ to each file
                List<string> xmlLoc = new List<string>();
                //get the files in directories
                string[] getFiles;
                //contains the files of each directory
                List<string> xmlList = new List<string>();
    
                //Add \ each paths variable and store it in xmlLoc list
                foreach (string s in paths)
                {
                     xmlLoc.Add(s + @"\");
                }
    
                //get the xml files of each directory in xmlLoc and store it in xmlList
                foreach (string file in xmlLoc)
                {
                     getFiles = Directory.GetFiles(file, "*.xml");
                     //the code below lists an error "cannot convert from string[] to string"
                     xmlList.AddRange(getFiles);
                }
