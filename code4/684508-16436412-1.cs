    public List<T> GetSmallestPosting()
    {
        if(_Index!=null)
           return  _Index.Values.First(v => v.Count == _Index.Min(kv => kv.Value.Count)).ToList();
    
        return null;
    }
    public List<T> GetLongestPosting()
    {
        if(_Index!=null)
          return   _Index.Values.First(v => v.Count == _Index.Max(kv => kv.Value.Count)).ToList();
    
        return null;
    }
