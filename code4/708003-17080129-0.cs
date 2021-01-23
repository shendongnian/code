    class Program
    {
        private static string StringFromIndexPermutation(char[] characters, int[] indexes)
        {
            var buffer = new char[indexes.Length];
            for (var i = 0; i < buffer.Length; ++i)
            {
                buffer[i] = characters[indexes[i]];
            }
            return new string(buffer);
        }
        /// <summary>
        /// Increments a set of "digits" in a base "numberBase" number with the MSD at position 0
        /// </summary>
        /// <param name="buffer">The buffer of integers representing the numeric string</param>
        /// <param name="numberBase">The base to treat the digits of the number as</param>
        /// <returns>false if the number in the buffer has just overflowed, true otherwise</returns>
        private static bool Increment(int[] buffer, int numberBase)
        {
            for (var i = buffer.Length - 1; i >= 0; --i)
            {
                if ((buffer[i] + 1) < numberBase)
                {
                    ++buffer[i];
                    return true;
                }
                
                buffer[i] = 0;
            }
            return false;
        }
        /// <summary>
        /// Calculate all the permutations of some set of characters in a string from length 1 to maxLength
        /// </summary>
        /// <param name="characters">The characters to permute</param>
        /// <param name="maxLength">The maximum length of the permuted string</param>
        /// <returns>The set of all permutations</returns>
        public static IEnumerable<string> Permute(char[] characters, int maxLength)
        {
            for (var i = 0; i < maxLength; ++i)
            {
                var permutation = new int[i + 1];
                yield return StringFromIndexPermutation(characters, permutation);
                while (Increment(permutation, characters.Length))
                {
                    yield return StringFromIndexPermutation(characters, permutation);
                }
            }
        }
        static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        private static int ReadIntegerRange(string message, int min, int max)
        {
            Console.Write(message + "({0} - {1})", min, max);
            while(true)
            {
                var test = Console.ReadLine();
                int value;
                if (int.TryParse(test, out value))
                {
                    return value;
                }
            }
            return -1;
        }
        static void OptionBruteForce()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("----- Brute-Force -----");
            Console.WriteLine("-----------------------");
            var password = ReadString("Enter the MD5 password hash to brute-force: ");
            var chars = ReadString("Enter the characters to use: ").Distinct().ToArray();
            var maxLength = ReadIntegerRange("Max length of password: ", 1, 16);
            var myStopWatch = Stopwatch.StartNew();
            var result = false;
            string match = null;
            var cancellationTokenSource = new CancellationTokenSource();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var originalMd5 = MD5.Create();
            var passwordHash = originalMd5.ComputeHash(passwordBytes);
            var hashAlgGetter = new ConcurrentDictionary<Thread, MD5>();
            try
            {
                Parallel.ForEach(Permute(chars, maxLength), new ParallelOptions
                {
                    CancellationToken = cancellationTokenSource.Token
                }, test =>
                {
                    var md5 = hashAlgGetter.GetOrAdd(Thread.CurrentThread, t => MD5.Create());
                    var data = Encoding.Default.GetBytes(test);
                    var hash = md5.ComputeHash(data);
                    if (hash.SequenceEqual(passwordHash))
                    {
                        myStopWatch.Stop();
                        match = test;
                        result = true;
                        cancellationTokenSource.Cancel();
                    }
                });
            }
            catch (OperationCanceledException)
            {
            }
            if (!result)
            {
                Console.WriteLine("No Match.");
            }
            else
            {
                Console.WriteLine("Password is: {0}", match);
            }
            Console.WriteLine("Took " + myStopWatch.ElapsedMilliseconds + " Milliseconds");
        }
        static void Main()
        {
            OptionBruteForce();
            Console.ReadLine();
        }
    }
