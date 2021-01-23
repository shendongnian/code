    Type objType = obj.GetType();
            MethodInfo info = objType.GetMethod("Write");
            if (objType.IsSubclassOf(info.DeclaringType))
            {
                Console.WriteLine("Not Override");
            }
            else
                Console.WriteLine("Override");
`
