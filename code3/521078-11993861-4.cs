            foreach (IEnumerable<char> outerEnumerator in permutations(test))
            {
                foreach (char singleChar in outerEnumerator)
                {
                    Console.Write(singleChar);
                }
                Console.WriteLine();
            }
