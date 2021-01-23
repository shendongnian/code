    public bool Contains(IEnumerable<T> needle) {
      return IndexOf(needle)!=-1;
    }
      
    public int IndexOf(IEnumerable<T> needle) {
      return Enumerable.Range(0,this.Count()).Where(i=> needle.SequenceEqual(this.Skip(i).Take(needle.Count()))).Select(i=>(int?)i).FirstOrDefault() ?? -1;
    }
