    short sNum;
    string input;
    do
    {
        input = Console.ReadLine();
    } while (!Int16.TryParse(input, out sNum))
    Console.WriteLine("output is {0}", sNum);
