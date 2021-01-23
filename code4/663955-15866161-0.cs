     public dynamic GetValue(string name)
     {
         if (OpcDataList[name].IsChanged)
         {
             OpcReflectItem tmpItem = OpcDataList[name];
             tmpItem.IsChanged = false;
             OpcDataList[name] = tmpItem;
         }
         return Convert.ChangeType(OpcDataList[name].ItemValue.Value, OpcDataList[name].DataType);
     }
