            public IEnumerable<int> Power(int number, int exponent)
            {
                int counter = 0;
                int result = 1;
                while (counter++ < exponent)
                {
                    result = result * number;
                    yield return result;
                }
            }
            public void UseIt()
            {
                foreach(var i in Power(2,5).Hide())
                {
                    Debug.WriteLine(i);
                }
            }
