            string input = " aa aaa aaaa bb bbb bbbb cc ccc cccc ";
            var list = input.Split(' ');
            var grouped = list.GroupBy(s => s.Length);
            foreach (var elem in grouped)
            {
                Console.WriteLine(elem.Key);
                foreach (var el in elem)
                {
                    Console.WriteLine(el);
                }
            }
