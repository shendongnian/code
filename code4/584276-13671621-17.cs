    foreach (string targetMachine in targetMachines)
    {
        Task<int>.Factory.StartNew(()=>Magic(targetMachine))
            .ContinueWith(t =>
            {
                if (t.Result == 2)
                {
                    DoSomething();
                }
            });
    }
