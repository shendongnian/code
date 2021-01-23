            const string test = "aabccc"; // contains barber pole characters
            Console.WriteLine(test);
            var longest = test.ToCodepoints().RunLengthEncode().OrderByDescending(itemCount => itemCount.Item2).First();
            var subsequence = String.Concat(Enumerable.Repeat(Char.ConvertFromUtf32(longest.Item1), longest.Item2));
            Console.WriteLine(subsequence);
