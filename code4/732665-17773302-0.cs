    string name = "..."; // Full name of your class
    Type typeObj = Type.GetType(name);
    // Get the default constructor
    ConstructorInfo constr = typeObj.GetConstructor(new Type[0]);
    // Invoke the constructor to create the object
    stateComponent = (IState)constr.Invoke(new object[0]);
