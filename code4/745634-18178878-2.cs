        public static async void PostDataToWebApi(MyDataClass tData)
            {
            await throttler.WaitAsync();
            allTasks.Add(Task.Run(async () =>
            {
                
                try
                {
                    var s = await client.PostAsJsonAsync("/api/Station/Collector", tData).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR (ClientPost): " + e.ToString());
                }
                finally
                {
                    throttler.Release();
                }
            }));
        }
