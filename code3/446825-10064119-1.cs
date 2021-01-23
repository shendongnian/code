    var counter = statuscounts.AsEnumerable()
                        .Aggregate(new Counter(), (c, a) => {
                                switch (a.Status)
                                {
                                    case 1: c.CountOfOnes = a.Count; return c;
                                    case 2: c.CountOfTwos = a.Count; return c;
                                    case 3: c.CountOfThrees = a.Count; return c;
                                    default: c.CountOfOthers = a.Count; return c;
                                }});
