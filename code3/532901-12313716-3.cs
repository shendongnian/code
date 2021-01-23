    class Program
    {
        static void Main(string[] args)
        {
            // same type
            var myCollection = new List<string> {"Hello", "World"};
            var array = (string[])myCollection.ConvertToArray();
            Console.WriteLine(array[0]);
            // new type
            var intList = new List<int> {1, 2, 3};
            var stringArray = (string[])intList.ConvertToArray(typeof(string));
            Console.WriteLine(stringArray[0]);
            // mixed types
            var ouch = new List<object> {1, "Mamma", 3.0};
            var result= (string[])ouch.ConvertToArray(typeof(string));
            Console.WriteLine(result[0]);
         
        }
    }
