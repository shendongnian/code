        static void Main(string[] args)
        {
            List<MyData> source = new List<MyData>();
            int itemsCount = 20;
            for (int i = 0; i < itemsCount; i++)
            {
                source.Add(new MyData() { Data = "mydata" + i });
            }
            
            IEnumerable mItemsource = source;
           
            //Remove Sample of an mItemSource
            dynamic d = mItemsource;
            d.RemoveAt(0);
            //check data
            string s = source[0].Data;
        }
        public class MyData { public string Data { get; set; } }
