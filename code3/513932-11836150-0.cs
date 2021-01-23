     class Program
        {
            static void Main(string[] args)
            {
                String strFilePath;
                String strLine;
                Int32 intMaxLineSize;
    
                strFilePath = [File path and name];                            
                StreamReader objFile= null;
    
                objFile = new StreamReader(strFilePath);
    
                intMaxLineSize = File.ReadAllLines(strFilePath).Max(line => line.Length);
                
                //Get the first line
                strLine = objFile.ReadLine();
    
                GetFieldNameAndFieldLengh(strLine, intMaxLineSize);
    
    
                Console.WriteLine("Press <enter> to continue.");
                Console.ReadLine();
            }
            public static void GetFieldNameAndFieldLengh(String strLine, Int32 intMaxSize)
            {            
                Int32 x;            
                string[] fields = null;
                string[,] strFieldSizes = null;
                Int32 intFieldSize;
                
                fields = SplitWords(strLine);
    
    
                strFieldSizes = new String[fields.Length, 2];
                x = 0;
    
                foreach (string strField in fields)
                {
                    if (x < fields.Length - 1)
                    {
                        intFieldSize = strLine.IndexOf(fields[x + 1]) - strLine.IndexOf(fields[x]);                    
                    }
                    else
                    {
                        intFieldSize = intMaxSize - strLine.IndexOf(fields[x]);
                    }
                    strFieldSizes[x, 0] = fields[x];
                    strFieldSizes[x, 1] = intFieldSize.ToString();
                    x++;
                }
                Console.ReadLine();
           
    
            }
    
            static string[] SplitWords(string s)
            {
                return Regex.Split(s, @"\W+");
            }
        }
