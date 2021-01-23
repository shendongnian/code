     public IEnumerable<string> GetAllDescriptionInText()
     {
         List<string> descList = new List<string>();
         foreach (DescriptionAttribute desc in Enum.GetValues(typeof(DescriptionAttribute)))
         {
             descList.Add(GetDescription(desc).Value);
         }
         return descList;
     }
