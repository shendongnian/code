                System.Collections.Hashtable objHashtable = new       System.Collections.Hashtable();
                // check to kill the right process
                foreach (System.Diagnostics.Process processInExcel in objProcess)
                {
                        if (objHashtable.ContainsKey(processInExcel.Id) == false && processInExcel.MainWindowTitle.ToString() == "")
                            processInExcel.Kill();
                }
                objProcess = null;
            }
