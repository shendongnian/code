        public class ListInheritanceTest
        {
            public void Test1()
            {
                List<string> list = new List<string>() { "1", "2", "3", "4", "5" };
                
                MyList<string> myList = new MyList<string>();
                myList.AddRange(list);
    
                foreach (var item in myList)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public class MyList<T> : List<T>
        {
        }
