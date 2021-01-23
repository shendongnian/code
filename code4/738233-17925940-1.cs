    _subscription = Observable
                .FromEventPattern<NewLoanEventHandler, NewLoanEventArgs>(
                    h => loan.NewLoanEvent += h, 
                    h => loan.NewLoanEvent -= h)
                .Take(1)
                .Select(a => a.EventArgs.Counterpatry)
                .GroupBy(c => c.Name)
                .SelectMany(grp => grp.Max( c => c.MaturityDate ).Select( maturity => new {grp.Key, maturity}) )
                .Subscribe( 
                    i => Console.WriteLine("{0} --> {1}", i.Key, i.maturity),
                    Console.WriteLine,
                    () => Console.WriteLine("completed")
                    );
