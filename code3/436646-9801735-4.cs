    public class TestClass
    {
        public void TestMethod(string param1, string param2)
        {
            string nameOfParam1 = MemberInfoGetting.GetMemberName(() => param1);
        }
    }
