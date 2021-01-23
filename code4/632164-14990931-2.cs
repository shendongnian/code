    public class ParentClass 
    {
        public static ParentClass GetNewObjectOfType(ClassType type)
        {
            switch(type)
            {
                case ClassType.ClassA: 
                    return new ClassA();
                    break;
                case ClassType.ClassB:
                    return new ClassB();
                    break;
            }
    
            return null;
        }
    }
    
    public class ClassA:ParentClass
    {
        //....
    }
    public class ClassB:ParentClass
    {
        //.......
    }
