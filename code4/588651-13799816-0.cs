    public virtual List<T> GetAllItems(Type DalType)//this is baseDAL
    {
      MethodInfo methodInfo = DalType.GetMethod("ConvertToBusinessEntities");
      object[] parametersArray = new object[] { itemCollection };
      object classInstance = Activator.CreateInstance(DalType, null);
      return (List<T>)methodInfo.Invoke(classInstance, parametersArray);
    }
