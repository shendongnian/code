    var statsModel =(
    		from message in _db.Messages
    		group message by 1 into g
    		select new
    		{
    			Total = g.Count(),
    			Approved =g.Count (x =>x.Approved),
    			Rejected =g.Count (x =>!x.Approved)
    		}
    	);
