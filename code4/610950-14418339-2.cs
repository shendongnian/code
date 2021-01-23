    Context.Jobs
    .Select(x => new { Job = x, Applicants = x.Applicants })
    .AsParallel()
    .WithDegreeOfParallelism(5)
    .ForAll(
           x => testList.Add(x.Applicants.Count().ToString())
       );
