    Using System.Threading.Tasks;    
    async void TimeUpdater()
        {
            while (true)
            {
                TxtTime.Text = DateTime.Now.ToString();
                await Task.Delay(1000);
            }
        }
