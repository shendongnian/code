        public void Run(IBackgroundTaskInstance taskInstance)
        {
            updateAllTiles(taskInstance);
        }
        public async void updateAllTiles(IBackgroundTaskInstance taskInstance)
        {
            // Need to use a deferral to run async tasks in the background task
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
            dosomething(taskInstance);
            deferral.Complete();
        }
        private async void dosomething(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
            HttpClient client = new HttpClient();
            HttpResponseMessage resp = await client.GetAsync(new Uri(url));
            updateTile(resp);
            deferral.Complete();
        }
