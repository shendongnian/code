    public List<Task<string>> tasksList = new List<Task<string>>(); // List of tasks being created
        public IList<WebsiteResult> WebResult = new List<WebsiteResult>(); // List that holds the web results
        private void CheckNewResult()
        {
            Task.Factory.ContinueWhenAll(tasksList.ToArray(), CompleteTasks);
        }
        //Only runs if all tasks Ran to Completion
        private void CompleteTasks(Task<string>[] tasks)
        {
            tasks.Where(x => x.Status == TaskStatus.RanToCompletion).ForEach(x => {
                Console.WriteLine(x.Result);
            }); 
        } 
