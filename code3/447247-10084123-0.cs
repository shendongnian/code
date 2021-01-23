    Dictionary<int, IObservable<IAsset>> inflightRequests;
    public IObservable<IAsset> GetSomeAsset(int id)
    {
        // People who ask for an inflight request just get the
        // existing one
        lock(inflightRequests) {
            if inflightRequests.ContainsKey(id) {
                return inflightRequests[id];
            }
        }
        // Create a new IObservable and put in the dictionary
        lock(inflightRequests) { inflightRequests[id] = ret; }
        // Actually do the request and "play it" onto the Subject. 
        var ret = new AsyncSubject<IAsset>();
        GetSomeAssetForReals(id, result => {
            ret.OnNext(id);
            ret.OnCompleted();
            // We're not inflight anymore, remove the item
            lock(inflightRequests) { inflightRequests.Remove(id); }
        })
        return ret;
    }
