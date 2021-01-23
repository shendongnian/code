    using (var context = new ChartContext())
    {
        var state1 = new State { Name = "State1" };
        var state2 = new State { Name = "State2" };
        var chart =
            new Chart
            {
                Initial = state1,
                States = new List<State> { state1, state2 }
            };
        context.Charts.Add(chart);
        context.SaveChanges();
    }
