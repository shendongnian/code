    Task.Factory.ContinueWhenAll(
                                tasks,
                                (antecedents) =>
                                {
                                    int answer = tasks[0].Result + tasks[1].Result;
                                    Console.WriteLine("The answer is {0}", answer);
                                });
    
    //StartNew - starts task immediately
    var parent = Task.Factory.StartNew(() => 
        {
            var child = Task.Factory.StartNew(() =>
            {
                //...
            });
        });
