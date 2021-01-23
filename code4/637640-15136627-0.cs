    var objTask = new Data.Task()
        {
            Message = new Data.Message()
    				{
    					Body = "",
    					Subject = ""
    				}
        };
    	Context.Tasks.InsertOnSubmit(objTask);
        Context.SubmitChanges();
