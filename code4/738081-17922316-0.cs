    var myClass = dt.AsEnumerable()
                    .Aggregate(new MyClass(),
                               (a,r) => {
                                    a.CatSum += r["Cat"].ToDecimalOrZero();
                                    a.DogSum += r["DogS"].ToDecimalOrZero();
                                    return a;
                               });
