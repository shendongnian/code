    public int AddMemVote(tMemVoteScore mvs)
    {
        //Insert Model
        using(CongressDBEntities context = new CongressDBEntities())
        {
            context.tMemVoteScores.Add(mvs);
            context.SaveChanges();
    
            int newPK = mvs.MemVoteScoresID;
    
            //Update funky column ID with PK as well
            var memVoteItem = (from m in context.tMemVoteScores
                               where m.MemVoteScoresID == newPK
                               select m).SingleOrDefault();
    
            memVoteItem.ID = memVoteItem.MemVoteScoresID;
            context.SaveChanges();
        }
        return newPK;
    }
