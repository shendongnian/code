     void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<Chat>();
            context.Clients.All.addMessage("Hello");      
        }
