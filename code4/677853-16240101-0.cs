    class TestClass
    {
        static Action a = TestMetod;
        static Delegate c = a;
        static void TestMetod()
        {
            MessageBox.Show("it worked !");
        }
    }
