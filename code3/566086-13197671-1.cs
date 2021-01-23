    public void UpdateDocument(UpdateTaskVO inputParams)
    {
        try
        {
            TaskVO taskDoc = GetTaskByID(inputParams.TaskID);
    
            switch (inputParams.FieldName)
            {
                ...
            }        
    
            String json = JsonConvert.SerializeObject(taskDoc);
            client.ExecuteStore(StoreMode.Set, inputParams.TaskID, json, taskDoc.Cas); 
            //this will fail if the document has been updated by another user.  You could use a retry strategy    
        }
        catch (Exception ex)
        {
            Console.Write("Exception :" + ex.Message);
        }
    }
