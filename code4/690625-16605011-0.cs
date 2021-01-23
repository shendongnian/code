      Connection.Send(....).ContinueWith(task => {
            if(!task.IsFaulted) 
            {
                // Task ran successfully    
            }
            else 
            {
                // Something went wrong when sending, you can get the exception from the task
            }
        });
        return Connection.Broadcast(data);
