                Dictionary<string, string> dicLabelData = new Dictionary<string, string>();
                List<string> listStrSplit = new List<string>();
                listStrSplit = strBig.Split(';').ToList<string>();//strBig is big string which you want to parse
    
                foreach (string strSplit in listStrSplit)
                {
                    if (strSplit.Split(':').ToList<string>().Count > 1)
                    {
                        List<string> listLable = new List<string>();
                        listLable = strSplit.Split(':').ToList<string>();
    
                        dicLabelData.Add(listLable[0],listLable[1]);//Key=Label,Value=Data
                    }
                }
