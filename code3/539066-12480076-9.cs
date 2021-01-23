    private void bgWorker_ProgressChanged(object sender,
        ProgressChangedEventArgs e)
    {
       //Set the  e.UserState to whatever you need. It is of type Object.
        var returnedObjects = e.Userstate as List<string>;
        if(returnedObjects != null)
        {
            //do stuff with each of your returnedObjects[i];
        }
      
    }
