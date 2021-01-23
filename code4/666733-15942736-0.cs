    public void SaveTasks(List<Task> tasks){
        //important that tasks already have personId --set on client side
        foreach(var task in Tasks){
          //do some validation
          db.Tasks.Add(task);
        }
        db.SaveChanges();
        
    }
 
