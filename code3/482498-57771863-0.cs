     Delegate[] listAllRegisteredMethods = writer.GetInvocationList(); //writer is the variable based on the question example
            
            foreach(Delegate c in listAllRegisteredMethods )
            {
                object[] p = { }; //Insert your parameters here inside the array
                c.DynamicInvoke(p); //Invoke it, on my part all don't have return values
            }
