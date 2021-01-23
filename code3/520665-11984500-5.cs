    var x= new[] {1,2,2,3,4,4,4};
    var y=x.Aggregate(Tuple.Create(new List<int>(),new List<int>()),
    (a,b) =>{
       if (a.Item2.Count()>0 && a.Item2[0] != b) {
         if (a.Item2.Count>a.Item1.Count()) {
    	   a=Tuple.Create(a.Item2,new List<int>());
    	 }
    	 a.Item2.Clear();
       }
       a.Item2.Add(b);
       return a;
    },a=>(a.Item2.Count() > a.Item1.Count()) ? a.Item2 : a.Item1);
