    public class SpreadsheetExample
    {
        public DateTime InTime { get; set; }
        public string InLocation { get; set; }
    
        public SpreadsheetExample(DateTime inTime, string inLocation)
        {
            InTime = inTime;
            InLocation = inLocation;
        }
    
        public static List<SpreadsheetExample> LoadMockData()
        {
            int maxMock = 10;
            Random random = new Random();
            var result = new List<SpreadsheetExample>();
            for (int mockCount = 0; mockCount < maxMock; mockCount++)
            {
                var genNumber = random.Next(1, maxMock);
                var genDate = DateTime.Now.AddDays(genNumber);
                result.Add(new SpreadsheetExample(genDate, "Location" + mockCount));
            }
    
            return result;
        }
    }
    
    internal class Class1
    {
        private static void Main()
        {
            var mockData = SpreadsheetExample.LoadMockData();
            var orderedResult = mockData.OrderBy(m => m.InTime).ThenBy(m => m.InLocation);//Order, ThenBy can be used to perform ordering of two columns
    
            foreach (var item in orderedResult)
            {
                Console.WriteLine("{0} : {1}", item.InTime, item.InLocation);
            }
        }
    }
