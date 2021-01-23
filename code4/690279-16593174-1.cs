    class A
    {
    }
    static class AExtensions
    {
        void F(this A a)
        {
            if (a == null)
            {
                throw new NullReferenceException();
            }
            //do stuff
        }
    }
