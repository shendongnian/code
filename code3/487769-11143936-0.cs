     List<T> GetInputParameters<T>(string spFunViewName, Func<string, string, int, T> itemCreator)
     {
        ....
        List<T> paramList = new List<T>();     
        foreach (string[] paramInfo in paramInfoList)     
        {         
           T t = itemCreator(paramInfo[NAME], paramInfo[TYPE], 
                Convert.ToInt32(paramInfo[CHARMAXLEN]));         
          paramList.Add(t);     
        }     
        return columnList;    
     }
 
