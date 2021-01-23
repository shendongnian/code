            var input = "janw doe";
            var people = new string[] { "abc", "123", "jane", "jane doe" };
            var found = Array.BinarySearch<string>(people, input);//or use FirstOrDefault(), FindIndex, search engine...
            if (found < 0)//not found
            {
                var i = input.ToArray();
                var target = "";
                //most similar
                //target = people.OrderByDescending(p => p.ToArray().Intersect(i).Count()).FirstOrDefault();
                //as you code:
                foreach (var p in people)
                {
                    var count = p.ToArray().Intersect(i).Count();
                    if (count > input.Length / 2)
                    {
                        target = p;
                        break;
                    }
                }
                if (!string.IsNullOrWhiteSpace(target))
                {
                    Console.WriteLine(target);
                }
            }
