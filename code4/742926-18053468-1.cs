     private string GetAllFreeItemNames(CategoryType catType)
    {
      if (this.DressingItems != null)
      {
        //var ls = FreeDressingItems;//.FindAll(I => I. == this.TypeName);
        return string.Join(",", this.DressingItems.Select(I => I.DressingInfo.ToString()).ToArray());
      }
    }
