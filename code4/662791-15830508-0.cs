    var a = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                string input = "GS190PA47";
                var x = Int32.Parse(new string(input.Reverse().TakeWhile(Char.IsDigit).Reverse().ToArray()));
            }
            a.Stop();
            var b = a.ElapsedMilliseconds;
            Console.WriteLine(b);
            a = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                string input = "GS190PA47";
                var x = Int32.Parse(Regex.Matches(input, @"\d+").Cast<Match>().Last().Value);
            }
            a.Stop();
             b = a.ElapsedMilliseconds;
            Console.WriteLine(b);
