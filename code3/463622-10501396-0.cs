    public static void ApplyROB(string  ROBread, string userName)
    {
    	using (SERTEntities ctx = CommonSERT.GetSERTContext())
    	{
    		var trUser= ctx.datUserRole.Where(a=>a.AccountName==userName)
                                       .FirstOrDefault();
    		if(trUser!=null)
    		{
    			trUser.ROB = ROBread;
    			trUser.AccountName = userName;
    		    ctx.SaveChanges();
    		}
    	}
    }
