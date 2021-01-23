    public List<Conversion> ReadFile()
        {
    
            List<Conversion> Convert = new List<Conversion>();
            using (StreamReader sr = new StreamReader(@"U:\convert.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] srArray;
                    str = sr.ReadLine();
    
                    srArray = str.Split(',');
                    Conversion currentConversion = new Conversion();
                    currentConversion.measurementA = srArray[0];
                    currentConversion.measurementB = srArray[1];
                    try{
                    currentConversion.converFac = decimal.Parse(srArray[2]);
                        }
                    catch(Exception ex){
                    Console.WriteLine("File is not in correct format");
                    break;
                    }
                    Convert.Add(currentConversion);
    
                }
    
    
            }
       return Convert;
        }
