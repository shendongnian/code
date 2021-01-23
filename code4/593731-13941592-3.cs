    public bool GetUserAuthorizedOnPeachIdUsingAChainQuery(int userid, int peachId)
    {
        using (var context = new MyDataDataContext())
        {
            bool isAuthorized = false;
        
            isAuthorized = context.PeachInventories.Where(p => p.PeachId == peachId)
                            .Join(context.FruitInventories.Where(f => f.UserId == userid), p => p.FruitId, f => f.FruitId, (p, f) => f).Any();
        
            return isAuthorized;
        
        }
    }
