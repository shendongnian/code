    Deployment.Current.Dispatcher.BeginInvoke(()=>
    { 
        Progressor.IsIndeterminate = Progressor.IsVisible = isOn;
        if (isOn) 
            At.Do(delegate { this.set(false); }, 1000);
    }
       
    });
