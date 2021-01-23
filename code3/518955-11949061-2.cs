      public bool Contains(IEnumerable<T> pattern) {
       return IndicesOf(pattern).Any();
     }           
     public int IndexOf(IEnumerable<T> pattern) {
       return IndicesOf(pattern).Select(x=>(int?)x).FirstOrDefault() ?? -1;
     }           
   
     public int LastIndexOf(IEnumerable<T> pattern) {
       return IndicesOf(pattern).Select(x=>(int?)x).LastOrDefault()?? -1;
     }           
     public IEnumerable<int> IndicesOf(IEnumerable <T> pattern) {
	  var count=pattern.Count();
      return Enumerable.Range(0,this.Count()-count).Where(i=> pattern.SequenceEqual(internalTake(i,count)));
     }           
     public IEnumerable<int> LastIndicesOf(IEnumerable<T> pattern) {
       return IndicesOf(pattern).Reverse(); // Could Optimize
     }
     private IEnumerable<IEnumerable<T>> internalSplit(IEnumerable<T> seperator) {
       var splitPoints=this.IndicesOf(seperator);
	   var length=seperator.Count();
	   var lastCount=0;
	   foreach(var point in splitPoints.Where(x=>!splitPoints.Any(y=>y<x && y+length>x))) {
	   		yield return this.Take(lastCount,point-lastCount);
			lastCount=point+length;
	   }
	   yield return this.TakeAll(lastCount);
     } 
     
 
     public ImmutableCollection<T>[] Split(IEnumerable<T> seperator) {
	   return internalSplit(seperator).Select(x=>new ImmutableCollection<T>(x)).ToArray();
     }          
 
     public bool StartsWith(IEnumerable<T> pattern) {
        return pattern.SequenceEqual(this.Take(pattern.Count()));
     }           
     public bool EndsWith(IEnumerable<T> pattern) {
        return pattern.SequenceEqual(this.Skip(this.Count()-pattern.Count()));
     }           
  
     private IEnumerable<T> internalTake(int startIndex, int length) {
	    var max=(length==-1) ? this.Count() : Math.Min(this.Count(),startIndex+length);
	    for (int i=startIndex;i<max;i++) yield return this[i];
	 }
     public ImmutableCollection<T> Take(int startIndex, int length) {
	    return new ImmutableCollection<T>(internalTake(startIndex,length));
     }           
     public ImmutableCollection<T> TakeAll(int startIndex) {
        return new ImmutableCollection<T>(internalTake(startIndex,-1));
     }           
