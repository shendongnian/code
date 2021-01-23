    public void DoFizzBuzz()
    {
        for (int i = 1; i <= 100; ++i)
        {
            bool isDivisibleByThree = i % 3 == 0;
            bool isDivisibleByFive = i % 5 == 0;
            if (isDivisibleByThree || isDivisibleByFive)
            {
                if (isDivisibleByThree)
                    cout << "Fizz";
    
                if (isDivisibleByFive)
                    cout << "Buzz";
            }
            else
            {
                cout << i;
            }
            cout << endl;
        }
    }
