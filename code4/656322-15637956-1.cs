    List<MyClass> myValues;
    public List<MyClass> LookUpFirstColumn(string value)
    {
        return this.myValues.Where(input => input.firstColumn == value).ToList();
    }
    //Methods to find other columns
  
