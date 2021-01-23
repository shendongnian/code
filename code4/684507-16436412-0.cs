    public List<T> GetSmallestPosting()
    {
        if(_Index!=null)
           return  _Index.Min(kv => kv.Value.Count).ToList();
    
        return null;
    }
    public List<T> GetLongestPosting()
    {
        if(_Index!=null)
          return   _Index.Max(kv => kv.Value.Count).ToList();
    
        return null;
    }
