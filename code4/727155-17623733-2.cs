    public IList<Research> GetReq(Dictionary<Research, List<Research>> reqs, 
                                  Research target)
    {
        var chain = new List<Research>();
        if(reqs.ContainsKey(target))
        {
            foreach(var item in reqs[target])
            {
                chain.Add(item);
                chain.AddRange(GetReq(reqs, item));
            }
        }
        return chain;
    }
