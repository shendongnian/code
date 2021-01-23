    public class MyClass
    {
        public MyClass()
        {
        }
    
    
        public void funct()
        {
        	var gl = new MyNamedLock("lock name");
            try
            {
                //Enter lock
                if (gl.enterLockWithTimeout())
                {
                    //Do work
                }
                else
                    throw new Exception("Failed to enter lock");
            }
            finally
            {
                //Leave lock
                gl.leaveLock();
            }
        }
    }
