            string YourStringVariable = "{noway|that's cool|1293328|why|don't know|see}";
            string[] SplitValue=g.Split('|');
            string FinalValue = string.Empty;
            for (int i = 0; i < SplitValue.Length; i++)
            {
                if (!SplitValue[i].ToString().Any(char.IsDigit))
                {
                    FinalValue += SplitValue[i]+"|";    
 
                }
                
            }
