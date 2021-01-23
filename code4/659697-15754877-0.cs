    private static void Process1(StreamWriter outFile, List<Assembly> assembliesList)
            {
                int MAXLIMIT = 200;
                string command = "mstest.exe ";
                string testcontainer = " /testcontainer:";
                List<string> testContainerAssemblies = new List<string>(4);
                int sum = 0;
    
                outFile.WriteLine("SET Path=%MsTestPath%");
    
                var res = (from x in assembliesList
                           group x by x.AssemblyName into g
                           select new
                            {
                                AssemblyNames = g.Key,
                                FullyQualifiedTestMethods = g.Select(i => " /test:" + i.NameSpaceName + "." + i.ClassName + "." + i.FunctionName),
                                FullyQualifiedTestMethodsLen = g.Select(i => Convert.ToString(" /test:" + i.NameSpaceName + "." + i.ClassName + "." + i.FunctionName).Length)
    
                            });
    
                foreach (var item in res)
                {
                    var assemblyNames = item.AssemblyNames;
                    var flag = true;
    
                    if (flag)
                    {
                        outFile.WriteLine(' ');
    
                        command = "mstest.exe ";
                        command += testcontainer + "\\" + item.AssemblyNames + " ";
                        //command += "/resultsfile:\"" + "\\Resultfile_" + assmbly.AssemblyName.Replace(".dll", "") + "_" + "1".ToString() + ".trx\"";
                        command += " /runconfig:";
                        command += " /detail:owner";
                        command += " /detail:duration";
                        command += " /detail:description";
    
                        command += " /unique ";
    
                        flag = false;
                    }               
    
    
                    var methodsLengths = item.FullyQualifiedTestMethodsLen.ToList();
    
                    for (int i = 0; i < methodsLengths.Count; i++)
                    {
                        sum += methodsLengths[i];
    
                        if (sum <= MAXLIMIT)
                        {
                            command += item.FullyQualifiedTestMethods.ToList()[i];
                            if (flag)
                            {
                                outFile.WriteLine(' ');
    
                                command = "mstest.exe ";
                                command += testcontainer + "\\" + item.AssemblyNames + " ";
                                //command += "/resultsfile:\"" + "\\Resultfile_" + assmbly.AssemblyName.Replace(".dll", "") + "_" + "1".ToString() + ".trx\"";
                                command += " /runconfig:";
                                command += " /detail:owner";
                                command += " /detail:duration";
                                command += " /detail:description";
    
                                command += " /unique ";
    
                                flag = false;
                            }
                        }
    
                        if (sum >= MAXLIMIT)
                        {
                            sum = 0;
                            flag = true;
                            outFile.Write(command);
                            i--;
                        }
                    }
                    outFile.Write(command);
    
                }
    
            }
