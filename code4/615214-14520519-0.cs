    public static void Main(string[] args)
            {
                //change rootDirectory variable to point to directory which you wish to scan through
                string rootDirectory = @"C:\sample";
                DirectoryInfo dir = new DirectoryInfo(rootDirectory);
    
                //get the LCIDs from the folders
                string[] filePaths = Directory.GetDirectories(rootDirectory);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    string LCID = filePaths[i].Split('\\').Last();
                    Console.WriteLine(LCID);
    
                    Thread t1 = new Thread(() => new HBScanner(new DirectoryInfo(filePaths[i])).HBscan());
                    t1.Start();
                }
    
                Console.WriteLine("Scanning through files...");
    
            }
            public class HBScanner
            {
                private DirectoryInfo DirectoryToScan { get; set; }
    
                public HBScanner(DirectoryInfo startDir)
                {
                    DirectoryToScan = startDir;
                }
    
                public void HBscan()
                {
                    HBscan(DirectoryToScan);
                }
    
                public static void HBscan(DirectoryInfo directoryToScan)
                {
                    //create an array of files using FileInfo object
                    FileInfo[] files;
                    //get all files for the current directory
                    files = directoryToScan.GetFiles("*.*");
                    string asset = "";
                    string lcid = "";
    
                    //iterate through the directory and get file details
                    foreach (FileInfo file in files)
                    {
                        String name = file.Name;
                        DateTime lastModified = file.LastWriteTime;
                        String path = file.FullName;
    
                        //first check the file name for asset id using regular expression
                        Regex regEx = new Regex(@"([A-Z][A-Z][0-9]{8,10})\.");
                        asset = regEx.Match(file.Name).Groups[1].Value.ToString();
    
                        //get LCID from the file path using regular expression
                        Regex LCIDregEx = new Regex(@"sample\\(\d{4,5})");
                        lcid = LCIDregEx.Match(file.FullName).Groups[1].Value.ToString();
    
                        //if it can't find it from filename, it looks into xml
                        if (file.Extension == ".xml" && asset == "")
                        {
                            System.Diagnostics.Debug.WriteLine("File is an .XML");
                            System.Diagnostics.Debug.WriteLine("file.FullName is: " + file.FullName);
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load(path);
                            //load XML file in 
    
                            //check for <assetid> element
                            XmlNode assetIDNode = xmlDoc.GetElementsByTagName("assetid")[0];
                            //check for <Asset> element
                            XmlNode AssetIdNodeWithAttribute = xmlDoc.GetElementsByTagName("Asset")[0];
    
                            //if there is an <assetid> element
                            if (assetIDNode != null)
                            {
                                asset = assetIDNode.InnerText;
                            }
                            else if (AssetIdNodeWithAttribute != null) //if there is an <asset> element, see if it has an AssetID attribute
                            {
                                //get the attribute 
                                asset = AssetIdNodeWithAttribute.Attributes["AssetId"].Value;
    
                                if (AssetIdNodeWithAttribute.Attributes != null)
                                {
                                    var attributeTest = AssetIdNodeWithAttribute.Attributes["AssetId"];
                                    if (attributeTest != null)
                                    {
                                        asset = attributeTest.Value;
                                    }
                                }
                            }
                        }
    
                        Item newFile = new Item
                        {
                            AssetID = asset,
                            LCID = lcid,
                            LastModifiedDate = lastModified,
                            Path = path,
                            FileName = name
                        };
    
                        Console.WriteLine(newFile);
    
                    }
    
                    //get sub-folders for the current directory
                    DirectoryInfo[] dirs = directoryToScan.GetDirectories("*.*");
                    foreach (DirectoryInfo dir in dirs)
                    {
                        HBscan(dir);
                    }
                }
            }
