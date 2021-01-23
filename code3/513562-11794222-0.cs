            string[] list = new string[]{
                        "1", "equal", "3", "perhaps", "6", "10", "378", 
                        "1937", "28936", "26543", "937",
                        "understood", "99993"
            };
            // Create sorted list (in a realistic scenario 
            // you would sort existing list)
            int[] firstMillionNumbers = new int[1000000];
            for (int i = 0; i < 1000000; i++)
                firstMillionNumbers[i] = i + 1;
            // Parse out numbers only
            List<int> listINT = new List<int>();
            int num;
            foreach (string s in list)
                if (int.TryParse(s, out num))
                    listINT.Add(num);
            // Find elements of one list inside another
            List<int> resultList = new List<int>();
            foreach(int num2 in listINT)
            {
                if (Array.BinarySearch(firstMillionNumbers, num2) > 0)
                    resultList.Add(num2);
            }
