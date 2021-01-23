    void MyMethod(Object obj)
    {
        if (obj is A)
        {
            A a = obj as A;
            ...
        } 
        else if (obj is B)
        {
            B b = obj as B;
            ...
        }
    }
