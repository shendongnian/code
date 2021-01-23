        void Test();
        int TestApp(int input);
    }
    public interface B
    {
        void Test();
        int TestApp(int input);
    }
    public class Testing : A, B
    {
        void A.Test()
        {
            throw new NotImplementedException();
        }
        int B.TestApp(int input)
        {
            throw new NotImplementedException();
        }
        void B.Test()
        {
            throw new NotImplementedException();
        }
        int A.TestApp(int input)
        {
            throw new NotImplementedException();
        }
    }
    public class TestingApp
    {
        public void DoOperation()
        {
            A testing = new Testing();
            // This will call interface A method
            testing.Test();
            B testing1 = new Testing();
            // This will call interface B method
            testing1.Test();
            //testing.Test();
        }
    }
