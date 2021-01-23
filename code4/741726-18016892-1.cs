    void SomeCode()
    {
        ...
        Action(3.0f); // calls float overload
        Action("hello"); // calls string overload
        ...
    }
    
    void Action(float a)
    {
        ...
    }
    void Action(int a)
    {
        ...
    }
    void Action(string a)
    {
        ...
    }
