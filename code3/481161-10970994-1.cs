    class MyGeneralClass
    {
        dynamic myVariable;
        Type type;
        public MyGeneralClass(Type type)
        {  
            this.type = type;
            myVariable = Activator.CreateInstance(type);
            //And then if your type is of a class you can use its methods      
            //e.g. myVariable.MyMethod();
        }
        //If your function return something of type you can also use dynamic
        public dynamic Funtion()
        {
            return Activator.CreateInstance(type);
        }
    }
