    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace SO14473321
    {
        class Program
        {
            static void Main()
            {
                UniqueRandom u = new UniqueRandom(Enumerable.Range(1,10));
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("{0} ",u.Next());
                }
            }
        }
        class UniqueRandom
        {
            private readonly List<int> _currentList;
            private readonly Random _random = new Random();
            public UniqueRandom(IEnumerable<int> seed)
            {
                _currentList = new List<int>(seed);
            }
            public int Next()
            {
                if (_currentList.Count == 0)
                {
                    throw new ApplicationException("No more numbers");
                }
                int i = _random.Next(_currentList.Count);
                int result = _currentList[i];
                _currentList.RemoveAt(i);
                return result;
            }
        }
    }
