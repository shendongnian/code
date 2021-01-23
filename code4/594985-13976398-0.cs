    Task outer = System.Threading.Tasks.Task.Factory.StartNew(() => AddAttachment(information.Subject, information.DocumentId.ToString(), information.Sender,list.Name))
    	.ContinueWith(task => {
    		if(task.IsFaulted)
    		{
    			AggregateException ex = task.Exception;
    			//handle exception
    		}
    	});
