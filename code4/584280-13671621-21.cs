    foreach (string targetMachine in targetMachines)
    {
        Task<int>.Run(()=>Magic(targetMachine))
            .ContinueWith(t =>
            {
                if (t.Result == 2)
                {
                    DoSomething();
                }
            });
    }
