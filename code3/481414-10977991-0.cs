    public IEnumerable<T> Randomize(this IEnumerable<T> source,int maxJump = 1000){
        var cache = new List<T>();
        var r = new Random();
        var enumerator = source.GetEnumerator();
        var totalCount = 1;
        while(enumerator.MoveNext()){
           var next = r.Next(0,maxJump);
           if(next < cache.Count){
              //the element we are searching for is in the cache
              yield return cache[next];
              cache.RemoveAt(next);
           } else {
             next = next - cache.Count;
             do{
              totalCount++;
              if(next == 0){
                 //we've found the next element so yield
                 yield return enumerator.Current;
              } else {
                 //not the element we are looking for so cache
                 cache.Insert(r.Next(0,cache.Count),enumerator.Current);
              }
              --next;
            }while(next > 0 && enumerator.MoveNext());
            //if we've reached half of the maxJump length
            //increase the max to allow for higher randomness
            if("*totalCount == maxJump){
                maxJump *= 2;
            }
          }
        }
        //Yield the elements in the cache
        //they are already randomized
        foreach(var elem in cache){
              yield return elem;
        }
    }
