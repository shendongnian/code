    public void Update(MyClass item, Expression<Func<MyClass, bool>> exp,
                                                string propertyName)
    {
       object propertyValue = item.GetType().GetProperty(propertyName)
                                   .GetValue(item, null);
       if(propertyValue != null)
       {
          // do your stuff here
       }
    }
