            void _triggerTimer_Tick(object sender, EventArgs e)
        {
            _triggerTimer.Stop();
            foreach (TriggerItem item in TriggerItems)
                if (item.Enabled)
                    while (item.TriggerTime <= DateTime.Now)
                        item.RunCheck(DateTime.Now);
                        System.Diagnostics.Process.Start("Your Path");
            _triggerTimer.Start();
        }
