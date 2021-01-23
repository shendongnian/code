        Timer JobTime = new Timer(timer =>
        {
            try
            {
                Console.WriteLine(DateTime.Now.ToString(), "TestJobTimer"); //Save invoke time to file
            }
            catch (Exception ex)
            {
                string stop = ex.Message;
            }
        });
        JobTime.Change(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(20));
