            object o = new int[] { 1, 2, 3 };
            //...
            if (o is IList)
            {
                IList l = o as IList;
                Console.WriteLine(l.Count);
            }
