    var objMessage = new Data.Message()
    {
        Body = "",
        Subject = ""
    };
    Context.Messages.InsertOnSubmit(objMessage);
    Context.SubmitChanges();
    var objTask = new Data.Task()
    {
        Message = objMessage
    };
    Context.Tasks.InsertOnSubmit(objTask);
    Context.SubmitChanges();
