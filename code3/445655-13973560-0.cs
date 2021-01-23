    [TestFixture("someurl1", "param1|param2", 15)]
    [TestFixture("someurl2", "param3", 15)]
    public class my_test
    {
        private string[] _fields;
        public my_test(string url, string fieldList, int someVal)
        {
            _fields = fieldList.Split('|');
            // test setup
        }
        [Test]
        public void listFields()
        {
            foreach (var field in _fields)
            {
                Console.WriteLine(field);
            }
        }
    }
