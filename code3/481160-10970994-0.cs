    class MyGeneralClass
    {
        dynamic myVariable;
    
        public MyGeneralClass(Type type)
        {  
            myVariable = Activator.CreateInstance(type);
            //And then if your type is of a class you can use its methods      
            //e.g. myVariable.MyMethod();
        }
    }
