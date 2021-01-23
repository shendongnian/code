    public void MyGenericMethod<T>(T something) //Base Method
    {
        // let the user pass in the correct item
    }
    
    public void MyGenericMethod<IList<T>>(IList<T> list, int index)  //Overload
    {
        MyGenericMethod(list[index]);
    }
