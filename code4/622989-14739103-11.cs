    var strategyI = new Strategy<int, P>(A.Condition, A.GetI);
    var strategyO = new Strategy<int, P>(A.Condition, A.GetO);
    var strategies = new List<Strategy<int, P>> {strategyI, strategyO};
    var context = new Context<int, P>(strategies.ToArray());
    var result = context.Evaluate(1); // should return a new I(), with 2 as param a new O()
    // once you get the result you can create a new context to work with the result
    var strategyWorkI = new Strategy<P, P>(Condition, WorkWithI);
    var stragegiesForWork = new List<Strategy<P, P>> {strategyWorkI} // could be more than one
    var workContext = new Context<P, P>(strategiesForWork.ToArray());
     
    var p = workContext.Evaluate(result); // does the right thing, but
                                          // no need to know class I here (only P)
    if (p == null)
      // seems to be something went wrong, throw? ...         
