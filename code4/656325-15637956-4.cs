    List<MyClass> myValues;
    public List<MyClass> LookUp(string value, int columnIndex)
    {
        return this.myValues.Where(
                         input => input.columns[columnIndex] == value
                                  ).ToList();     
    }
  
