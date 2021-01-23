        int[] ints = {1, 2, 3 };
        List<int> listInts = ints.ToList();
        MyMethod<int>(listInts);
        private static void MyMethod<T>(List<T> genericList)
        {
            // do you work
        }
