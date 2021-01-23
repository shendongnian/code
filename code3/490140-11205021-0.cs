    public void Searching(Expression<Func<User,string>> field, string stringToSearch)
    {
       var call = Expression.Call(field.Body, typeof (string).GetMethod("Contains"), new[] {Expression.Constant(value)});
       Expression<Func<User, bool>> exp = Expression.Lambda<Func<User, bool>>(Expression.Equal(call, Expression.Constant(true)), field.Parameters);
    	var res =  _dataContext.USERs.Where(exp).Select(u=>new { id= u.ID, Username = u.USERNAME});
    		    		
    }
