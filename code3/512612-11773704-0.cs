     string WordProcess(string StringToProcess, string InsertValue, byte NumberToProcess )
        {
            string Result = "";
            while (StringToProcess != "")
            {
                for (byte b = 0; b < NumberToProcess; b++)
                {
                    string TempString = StringToProcess;
                    Result += TempString.Remove(1, TempString.Length - 1);
                    StringToProcess = StringToProcess.Remove(0, 1);
                }
                Result += InsertValue;
            }
            return Result;
        }
