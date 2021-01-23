    Parallel.Invoke(
                new ParallelOptions{MaxDegreeOfParallelism=30},
                new Action[]
                    {
                        () => { users= service.DoAbc(); },
                        () => { products= service.DoDef(); }
                    });
