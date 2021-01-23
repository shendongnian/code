            string Tags = "the cat the mat the sat";
            string[] words = Tags.Split(' ');
            Dictionary<string, int> oddw = new Dictionary<string, int>();
            foreach (string item in words)
            {
                if (item != "")
                {
                    if (oddw.ContainsKey(item) == false)
                    {
                        oddw.Add(item, 1);
                    }
                    else
                    {
                        oddw[item]++;
                    }
                }
            }
            foreach (var item in oddw)
            {
                Console.WriteLine(item);
            }
