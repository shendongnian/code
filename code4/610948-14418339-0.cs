    var testList = new List<string>();
    Context.Jobs
    .Select(x => x.Applicants.Count().ToString())
    .AsParallel()
    .WithDegreeOfParallelism(5)
    .ForAll(
               x => testList.Add(x)
           );
