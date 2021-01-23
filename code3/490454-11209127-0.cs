        int index = 0;
        char[] result = new char[input.Length];
        System.Random RandNum = new System.Random();
        for (int i = 0; i < input.Length; i++)
        {
            int MyRandomNumber = RandNum.Next(0, 100);
            if ((input[i] == '|') && (MyRandomNumber < 35))
            {
                result[index++] = ' ';
            }
            else
                result[index++] = input[i];
        }
        return new string(result, 0, index);
