    private void RunTest()
    {
        try
        {
            List<TestObject> mylist = new List<TestObject>();
            for (int i = 0; i <= 1000000; i++)
            {
                TestObject testO = new TestObject(string.Format("Item{0}", i), 1, Guid.NewGuid().ToString());
                mylist.Add(testO);
            }
            mylist.Add(new TestObject("test", "29863", Guid.NewGuid().ToString()));
            string searchtext = "test";
            int iterations = 100;
            // Linq Lambda Test
            List<int> list1 = new List<int>();
            for (int i = 1; i <= iterations; i++)
            {
                DateTime starttime = DateTime.Now;
                TestObject t = mylist.FirstOrDefault(q => q.Name == searchtext);
                int diff = (DateTime.Now - starttime).Milliseconds;
                list1.Add(diff);
            }
            // Linq Where Test
            List<int> list2 = new List<int>();
            for (int i = 1; i <= iterations; i++)
            {
                DateTime starttime = DateTime.Now;
                TestObject t = (from testO in mylist
                                where testO.Name == searchtext
                                select testO).FirstOrDefault();
                int diff = (DateTime.Now - starttime).Milliseconds;
                list2.Add(diff);
            }
            // For Loop Test
            List<int> list3 = new List<int>();
            for (int i = 1; i <= iterations; i++)
            {
                DateTime starttime = DateTime.Now;
                foreach (TestObject testO in mylist)
                {
                    if (testO.Name == searchtext)
                    {
                        TestObject t = testO;
                        break;
                    }
                }
                int diff = (DateTime.Now - starttime).Milliseconds;
                list3.Add(diff);
            }
            float diff1 = list1.Average();
            Debug.WriteLine(string.Format("LINQ Lambda Query Average Time: {0} seconds", diff1 / (double)100));
            float diff2 = list2.Average();
            Debug.WriteLine(string.Format("LINQ Where Query Average Time: {0} seconds", diff2 / (double)100));
            float diff3 = list3.Average();
            Debug.WriteLine(string.Format("For Loop Average Time: {0} seconds", diff3 / (double)100));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }
    private class TestObject
    {
        public TestObject(string _name, string _value, string _guid)
        {
            Name = _name;
            Value = _value;
            GUID = _guid;
        }
        public string Name;
        public string Value;
        public string GUID;
    }
