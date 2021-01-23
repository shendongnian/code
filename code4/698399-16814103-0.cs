            IList<int> myList = new List<int>();
            string userInput = "";
            while (userInput != "0")
            {
                int myInt = 0;
                userInput = Console.ReadLine();
                if(Int32.TryParse(userInput, out myInt) && myInt > 0)
                {
                    myList.Add(myInt);
                }
            }
            Console.WriteLine(myList.Sum());
            Console.ReadLine();
