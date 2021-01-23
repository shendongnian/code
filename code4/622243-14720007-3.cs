    public class TestModels
    {
        public Dictionary<int, dynamic> sp = new Dictionary<int, dynamic>();
    
        public TestModels()
        {
            sp.Add(0, new {name="Test One", age=5});
            sp.Add(1, new {name="Test Two", age=7});
        }
    }
