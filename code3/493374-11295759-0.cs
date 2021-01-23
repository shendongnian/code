        string test2 = "CustomerNumberHello";
        for (int i = 1; i < test2.Length; i++)
        {
            if (test2[i] < 97)
            {
                test2 = test2.Remove(i, test2.Length - i);
                break;
            }
        }
        Console.WriteLine(test2); // Prints Customer
