    public Task<IEnumerable<S3Object>> continuation(Task<IEnumerable<S3Object>> task)
    {
        if(task.Result == null)  //not quite sure what null means here//may need to edit this recursive case
        {
            return Task<ListObjectsResponse>.Factory.FromAsync(
                    client.BeginListObjects, client.EndListObjects, listRequest, null)
                    .ContinueWith(continuation);
        }
        else if (task.Result.IsTruncated)
        {
            //if the results were trunctated then concat those results with 
            //TODO modify the request marker here; either create a new one or store the request as a field and mutate.
            return Concat(task.Result,
                Task<ListObjectsResponse>.Factory.FromAsync(
                    client.BeginListObjects, client.EndListObjects, listRequest, null)
                    .ContinueWith(continuation));//recursive continuation call
        }
        else //if we're done it means the existing results are sufficient
        {
            return task;
        }
    }
