    public bool GetUserAuthorizedOnPeachId(int userid, int peachId)
    {
        using(var context = new MyDataDataContext())
        {
            bool isAuthorized = false;
            isAuthorized = (from p in context.PeachInventories.Where(p => p.PeachId == peachId)
                                        join f in context.FruitInventories.Where(f => f.UserId == userid) on p.FruitId equals f.FruitId select p).Any();
        
            return isAuthorized;
        
        }
    }
