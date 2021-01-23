    public static void Main(string[] args)
            {
                Program myProgram= new Program();
    
                //prevent multiple instance of C# application
                
                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    Console.WriteLine("Only one instance allowed");
                    Environment.Exit(0);
                }
                else
                {
    
    
                    /*create target directory to store log files*/
    
                    DateTime dailyDate = DateTime.Now;
                   
    
                   String directoryTargetName =  myProgram.GetTargetDirectoryName(dailyDate);
                   
                    int count = 0;
                    //listing all files in disk
                    string[] a1 = Directory.GetFiles(@Settings.Default.SourceFolder);
    
    
                    //get free disk space
                    string sourceDriverName = Settings.Default.SourceFolder.Split(new char[] { System.IO.Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Last();
    
                    string targetDriverName = Settings.Default.TargetFolder.Split(new char[] { System.IO.Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Last();
    
                    /*Specify Target Directory and check its availability*/
    
    
                    string _directoryNameS = Settings.Default.TargetFolder + "\\" + directoryTargetName;
    
                    myProgram.CheckExistDirectory(_directoryNameS);
    
    
                    Boolean bFlag= myProgram.ControlOfCapacitySourceAndTargetDisc(sourceDriverName,targetDriverName);
                  
    
    
                    //Display all files
                    Console.WriteLine("-----Files -------");
                    foreach (string name in a1)
                    {
                        Console.WriteLine(name);
    
                    }
    
                    Console.WriteLine("----Sorted Array by creation date------");
    
                    //display sorting array
                    //sort file by creation date
    
                    IComparer fileComparer = new CompareFileByDate();
                    Array.Sort(a1, fileComparer);
    
                    foreach (string f in a1) // count file numbers
                    {
                        count++;
                        Console.WriteLine(f);
                    }
    
                    //Move directories to another disc
                    string destinationFile = @Settings.Default.TargetFolder; // destination disc
                    Console.WriteLine("**********************************************");
    
    
                    //calculate amount of moving from source to target disc
                    decimal AmountOfMoving = Convert.ToDecimal(count) * Settings.Default.AmountOfPercentForMovingFull;
                   
                    int countSon = Convert.ToInt32(AmountOfMoving);
    
    
                     // control of target disc's free space
                    decimal division = myProgram.GetDivision(sourceDriverName); // get division
                       
                    if (bFlag && division <= Settings.Default.WarningAmountOfFullSize) // what percent of disc is moving
                        {
                            Console.WriteLine("Warning,80 percent of disk is full");
                            Console.WriteLine("you must carry move files another free disk");
                            Console.WriteLine("%d of files are moving " + countSon);
    
                            foreach (string f in a1)
                            {
    
                                Console.WriteLine(f);
                                string lastDirectory = f.Split(new char[] { System.IO.Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Last();
    
                                File.Move(f, _directoryNameS + "\\" + lastDirectory); // store in dateTime directory
    
                                countSon--;
                                if (countSon == 0)
                                {
                                    break;
                                }
    
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have enough space for saving files..");
                        }
                   
                      
                   
    
                }
    
            }
