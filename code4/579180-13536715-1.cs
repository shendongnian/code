        private void showButton_Click(object sender, EventArgs e)
        {
            var myDurationSeconds = 5;
            var tooltip = new MyTooltip(
                5000,
                2000,
                50,
                50,
                "This is my custom tooltip message.");
            tooltip.Show();
            var ui = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Factory.StartNew(() => this.CloseAfter(
                tooltip,
                myDurationSeconds * 1000, 
                ui));
        }
        private void CloseAfter(Form form, int duration, TaskScheduler ui)
        {
            Thread.Sleep(duration);
            Task.Factory.StartNew(
                () => form.Close(),
                CancellationToken.None,
                TaskCreationOptions.None,
                ui);
        }
