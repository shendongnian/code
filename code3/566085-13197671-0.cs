    public TaskVO GetTaskByID(string task_id)
    {
        var getResult = oCouchbase.ExecuteGet<string>(task_id);   
        var results = JsonConvert.DeserializeObject<TaskVO>(str1.Value);
        results.Cas = getResult.Cas; //Here I'm suggesting adding a Cas property to your TaskVO
        return results;
    }
