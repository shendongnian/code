     protected Class1() //base class ctor
        {
            StackFrame[] stackFrames = new StackTrace().GetFrames(); 
            foreach (var frame in stackFrames)
            {
                //check caller and throw an exception if not satisfied
            }
        }
