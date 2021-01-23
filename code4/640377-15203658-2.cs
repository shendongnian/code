    using System.Threading.Tasks;
    string val1 = null;
    bool val2 = false;
    var actions = new List<Action>();
    actions.Add(() =>
    {
         val1 = ac.Method1();
    });
    actions.Add(() =>
    {
         val2 = ac.Method2();
    });
    Parallel.Invoke(new ParallelOptions(), actions);
    // alternative - using Parallel.ForEach:
    // Parallel.ForEach(actions, action => action());
    // rest of your code here.....
