    public class StackOverflow_14944788
    {
        private static void MySpecialFunction(IEnumerable<MyObject> list, Func<MyObject, string> selector, int count = 3)
        {
            string result = string.Join(", ", list.Take(count).Select(selector));
            int listSize = list.Count();
            if (listSize > count)
            {
                result += ", and " + (listSize - count) + " more.";
            }
            Console.WriteLine(result);
        }
        public class MyObject
        {
            public string Text1 { get; set; }
            public string Text2 { get; set; }
            public MyObject(string text1, string text2)
            {
                Text1 = text1;
                Text2 = text2;
            }
        }
        public static void Test()
        {
            List<MyObject> myObjects = new List<MyObject>();
            myObjects.Add(new MyObject("sample11", "sample12"));
            myObjects.Add(new MyObject("sample21", "sample22"));
            myObjects.Add(new MyObject("sample31", "sample32"));
            myObjects.Add(new MyObject("sample41", "sample42"));
            myObjects.Add(new MyObject("sample51", "sample52"));
            MySpecialFunction(myObjects, f => f.Text1);
            MySpecialFunction(myObjects, f => f.Text2);
        }
    }
