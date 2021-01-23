    for(int x = SwearJarController.Records.Count - 1 ; x >= 0; x--)
    {
        Record record = SwearJarController.Records[x];
        if(record.Word == "Hi")
        {
            SwearJarController.Records.Remove(record);
            Datastore.DB.Records.DeleteOnSubmit(record);
        }
    }
