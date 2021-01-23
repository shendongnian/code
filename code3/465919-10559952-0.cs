    foreach(var frame in StackTrace.GetFrames())
    { 
        System.Reflection.MethodBase method = frame.GetMethod ( );
        Type type = method.DeclaringType;
        
        if ( type.IsSubclassOf( typeof(TestClassBase)) ||  type != typeof ( TestClassBase) )
        {
            return type.Name + ( includeMethod ? '.' + method.Name : "" );
        }
    }
