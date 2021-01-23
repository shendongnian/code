     public static void SendCmdWithData(int IntCode, Hashtable Htbl)
            {
                DatawithCommandCode[] arrData = new DatawithCommandCode[Htbl.Count];
                try
                {
                    int i = 0;
                    foreach (System.Collections.DictionaryEntry element in Htbl)
                    {
                        DatawithCommandCode tempData = new DatawithCommandCode();
                        tempData.CmdCode = Convert.ToInt32(element.Key);
                        tempData.Value = Convert.ToInt32(element.Value);
                        arrData[i++] = tempData;
                    }
                }
                catch (Exception) { }
            }
