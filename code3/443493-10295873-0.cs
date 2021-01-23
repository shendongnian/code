    [SafeToPrepare(true)]  
    public static string GetNodeDescription(string MiningModel, string nodeUniqueName)  
    {  
      if (Context.ExecuteForPrepare)  
      {
        return string.Empty;  
      }  
      return Context.MiningModels[MiningModel].GetNodeFromUniqueName(nodeUniqueName).Descript‌​ion;  
    }
