    lstFiles = dirInfo.EnumerateFiles(searchPattern)
                      .Select(file => new ATTFile(){
                          FileName = file.Name;
                          Folder = file.Directory.ToString();
                          Size = int.Parse(file.Length.ToString());
                          Extension = file.Extension;
                      }).ToList();
