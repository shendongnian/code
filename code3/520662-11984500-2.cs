    IEnumerable<T> LongestSublist<T>(IEnumerable<T> source) {
    return source.Aggregate(Tuple.Create(new List<T>(),new List<T>()),
        (a,b) =>{
           if (a.Item2.Count()>0 && a.Item2[0] != b) {
             if (a.Item2.Count>a.Item1.Count()) {
        	   a=Tuple.Create(a.Item2,new List<T>());
        	 }
        	 a.Item2.Clear();
           }
           a.Item2.Add(b);
           return a;
        },a=>(a.Item2.Count() > a.Item1.Count()) ? a.Item2 : a.Item1);
