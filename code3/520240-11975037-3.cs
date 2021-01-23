    var tempList = input.Split(':')
                .SelectMany(s =>
                                {
                                    if (s.Contains(","))
                                    {
                                        var subList = s.Split(',');
                                        return new List<string>
                                                   {
                                                       string.Concat(subList.Take(subList.Length - 1)),
                                                       subList.Last()
                                                   };
                                    }
                                    return new List<string>() {s};
                                }).ToList();
            var values = tempList.Where(s => tempList.IndexOf(s) % 2 == 1);
            var ids = tempList.Where(s => tempList.IndexOf(s) % 2 == 0)
                                .SelectMany(s => s.Split(new[] { ',', ':' })
                                                  .Where(ss => !string.IsNullOrWhiteSpace(ss))
                            );
            var result = ids.Zip(values, (id, value) => string.Format("{0}: {1}", id, value));
                          
