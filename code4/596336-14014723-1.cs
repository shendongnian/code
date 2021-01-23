    // fill our container
                string DataContainer = string.Empty;
                using (StreamReader sr = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestFile.txt"))) {
                    DataContainer = sr.ReadToEnd();
                }
    
                // print data
                Match regMatch = Regex.Match(DataContainer, @"\'Max\'.*?\]\);", RegexOptions.Singleline);
                int verdiepc = 0;
                while (regMatch.Success) {
                    string[] Data = regMatch.Value.Replace("\r", "").Split('\n');
    
                    for (int I = 1; I < Data.Length - 1; I++) {
                        Console.WriteLine("Verdieping_{0}[{1}] = {2}"
                            , verdiepc, I, Data[I]);
                    }
                    Console.Write("\n");
    
                    verdiepc ++;
                    regMatch = regMatch.NextMatch();
                }
    
                // prevent immidiate exit
                Console.ReadKey();
