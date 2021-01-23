    new System.Threading.Thread(t =>
    {
      Application.Current.Dispatcher.Invoke((Action)delegate
      {
        OnHoldMessages.Add(_selectedOnHoldMessage);
        RaisePropertyChanged(propertyName: "OnHoldMessages");
      });
    }).Start();
