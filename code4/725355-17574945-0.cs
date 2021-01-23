    public void MyGenericMethod<T>(T something, int? index)
    {
       IList list = something as IList;
       if (list != null)
       {
          //Do Something
       }
       else
       {
          //Do something else
       }
    }
