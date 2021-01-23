     //False = 0, True = 1.
        private void DivisibilityByFiveThreeTest(int num)
        {
            string[,] values = new string [2,2]{
                                 {"None","Fizz"},
                                 {"Buzz","FizzBuzz"}
                                 };
            for(int i=1;i< num;i++)
            Console.WriteLine(values[Convert.ToInt32(i % 5 == 0), Convert.ToInt32(i%3==0)]);
        }
