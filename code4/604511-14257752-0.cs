     this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate()
            {                
                if (new DateTime(model.ComebackDate.Year, model.ComebackDate.Month, model.ComebackDate.Day) > DateTime.Now)
                {
                    new WndMessage("Date time error...").ShowDialog();
                    Switcher.Switch(new MainMenu());
                    return;
                }
    
                // ...............
            });     
