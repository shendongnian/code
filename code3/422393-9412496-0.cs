    //If you CAN access the instance
    var instance = new YourClass(); //instance of class implementing the interface
    var interfaces = instance.GetType().GetInterfaces();
    //Otherwise get the type of the class
    var classType = typeof(YourClass); //Get Type of the class implementing the interface
    var interfaces = classType.GetInterfaces()
