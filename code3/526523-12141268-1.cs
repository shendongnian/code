        void func(int x, int y, params object[] arr)
        {
            foreach (var a in arr)
            {
                if (a.GetType().IsArray)
                {
                    var internalArray = ((Array)a).OfType<object>().ToArray();
                    Console.WriteLine(internalArray[0]);
                }
                else if (a is IList)
                {
                    var internalList = (IList)a;
                    Console.WriteLine(internalList[0]);
                }
            }
        }
