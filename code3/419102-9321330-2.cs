	public Guid? InsertUpdate(News entity)
	{
	    return UsingSqlTransaction(sqlTrans =>
	    {
	        var token = data.InsertUpdate(sqlTrans, entity);
	        data.DoSomethingElse(sqlTrans, entity);
            return token;
	    });
	}
