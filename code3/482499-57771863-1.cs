     Delegate[] listAllRegisteredMethods = writer.GetInvocationList(); //writer is the variable based on the question example
            
            foreach(Delegate c in listAllRegisteredMethods )
            {
                object[] p = { }; //Insert your parameters here inside the array if your delegate has parameters
                c.DynamicInvoke(p); //Invoke it, if you have return values, assign it on a different variable
            }
