        static void Main(string[] args)
        {
            var param1String = "Life universe and everything";
            var param2Int = 42;
            var task = new Task((stateObj) =>
                {
                    var paramsArr = (object[])stateObj; // typecast back to array of object
                    var myParam1String = (string)paramsArr[0]; // typecast back to string 
                    var myParam2Int = (int)paramsArr[1]; // typecast back to int 
                    Console.WriteLine("");
                    Console.WriteLine(string.Format("{0}={1}", myParam1String, myParam2Int));
                },
                new object[] { param1String, param2Int } // package all params in an array of object
            );
            Console.WriteLine("Before Starting Task");
            task.Start();
            Console.WriteLine("After Starting Task");
            Console.ReadKey(); 
        }
