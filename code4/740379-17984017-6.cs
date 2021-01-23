    class MyClass
    {
        int e;
        void MyMethod()
        {
            try
            {
                DoSomething(e); //Here it is the Int32 field
            }
            catch (Exception e)
            {
                OhNo(e); //Here it is the exception
                DoSomethingElse(this.e); //Here it is the Int32 field
            }
        }
    }
