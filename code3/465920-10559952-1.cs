        foreach(var frame in StackTrace.GetFrames())
        { 
            System.Reflection.MethodBase method = frame.GetMethod ( );
            Type type = method.DeclaringType;
            // If this is what I am looking for
            if ( type.IsSubclassOf( typeof(TestClassBase)) ||  type != typeof ( TestClassBase) )
            {
                System.Console.WriteLine("Success, File {0}, Line {1}", frame.GetFileName(), frame.GetFileLineNumber());
                return;
            }
        }
