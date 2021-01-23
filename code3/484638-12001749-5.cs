            public IEnumerable<int> Power(int number, int exponent)
            {
                int counter = 0;
                int result = 1;
                while (counter++ < exponent)
                {
                    if (result>Int16.MaxValue) throw new Exception();
                    result = result * number;
                    yield return result;
                }
            }
            public void UseIt()
            {
                foreach(var i in Power(Int32.MaxValue-1,5).Hide())
                {
                    Debug.WriteLine(i);
                }
            }
