    var sortedList2 = unsortedList
                    .OrderBy(foo => foo.Bar)
                    .GroupBy(foo => foo.Bar);
    
                var result = new List<Foo>();
                foreach (var s in sortedList2)
                {
                    if (s.Count() > 1)
                    {
                        var ordered = s
                            .OrderBy(el => el.GetCurrentValue());
                        result.AddRange(ordered);
                    }
                    else
                    {
                        result.AddRange(s);
                    }
                }
