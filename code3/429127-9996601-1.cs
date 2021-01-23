    // Suppose we have observables o1, o2, ..., o9. All IObservable<int>.
    var o1and2 = o1.And(o2); // Store this bad boy for later use. Pattern<int, int>
    var o5and6and9 = o5.And(o6).And(o9).Then((t1,t2,t3) => t1+t2+t3); // Plan<int>
    var o3and7 = o3.And(o7).Then((t1,t2) => string.Format("Result: {0}", t1+t2)); // Plan<string>
    var o12ando8and6 = o1and2.And(o8).And(o6).Then((t1,t2,t3,t4) => new Tuple((decimal)t1, t2, t3.ToString(), t4)); // Plan<Tuple<decimal, int, string, int>>
    // When similar results together. This will fire when any of the Patterns give a result.
    var firstObserve = Observable.When(o1and2.Then((t1,t2) => t1+t2), o5and6and9); // IObservable<int>
    var secondObserve = Observable.When(o3and7); // IObservable<string>
    var thirdObserve = Observable.When(o12ando8and6); // IObservable<Tuple<decimal, int, string,int>>
