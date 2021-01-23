            var timer = new SmartDispatcherTimer();
            timer.IsReentrant = false;
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.TickTask = async () =>
            {
                StatusMessage = "Updating...";  // MVVM property
                await UpdateSystemStatus(false);
                StatusMessage = "Updated at " + DateTime.Now;
            };
            timer.Start();
