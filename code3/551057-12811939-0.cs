    private static void GetAnswerByLoopingNumbers(Stopwatch timer) 
    {
        int _counter = 1;
        for (int number = 123456789; number <= 987654321; number += 9)
        {
            string numToCheck = number.ToString();
            if (ContainsZero(numToCheck) || ContainsDuplicates(numToCheck))
                continue;
            _counter++;
            if (_counter != 100000)
                continue;
            timer.Stop();
            CheckAnswer(numToCheck, timer);
            break;
        } }
    private static bool ContainsDuplicates(IEnumerable<char> numToCheck)
    {
        IEnumerable<char> check = numToCheck as char[] ?? numToCheck.ToArray();
        foreach (char number in check)
        {
            int count = 0;
            foreach (char c in check)
            {
                if (c == number)
                    count++;
            }
            if (count > 1)
                return true;
        }
        return false;
    }
    private static bool ContainsZero(IEnumerable<char> numToCheck)
    {
        foreach (char number in numToCheck)
        {
            if (number == '0')
                return true;
        }
        return false;
    }
