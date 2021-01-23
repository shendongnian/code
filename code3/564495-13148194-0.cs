    public class Manager
    {
       public void PutRequest()
       {
           //Do Something
           if (!CheckIfResponseExists()) // returns boolean value
                LoadRequestFromDB()
           
            CallService(); 
            //Do Something
            SaveResponse();
       }
    }
