    static void Main(string[] args)
            {
                var list = SearchResult.GetResult();
                var wordArray = "Geo,JCB".Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                list.Sort((a, b) => {
                    int sum1 = 0, sum2=0;
                    foreach (var item in wordArray)
                    {
                        sum1 += Regex.Matches(a.Description, item).Count;
                        sum2 += Regex.Matches(b.Description, item).Count;
                    }
    
                    if (sum1 < sum2) return 1;
                    else if (sum1 > sum2) return -1;
                    else return 0;
                });
                foreach (var item in list)
                {
                    Console.WriteLine(item.Description);
                }
                Console.ReadKey();
            }
