            string[] list = new string[]{
                        "1", "equal", "3", "perhaps", "6", "10", "378", 
                        "1937", "28936", "26543", "937",
                        "understood", "99993"
            };
            // Create sorted list
            int[] firstMillionNumbers = Enumerable.Range(1, 1000000).ToArray();
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
                if (Array.BinarySearch(firstMillionNumbers, num2) >= 0)
                    resultList.Add(num2);
            }
