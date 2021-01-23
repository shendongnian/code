    var clickActions = new RoutedEventHandler[]
    {
           (o, e) =>
               {
                   // index 0
               },
           (o, e) =>
               {
                   // index 1
               },
           (o, e) =>
               {
                   // index 2
               },
    };
    for (int i = 0; i < clickActions.Length; i++)
    {
        Button acceptButton = new Button { Content = "Lösung" };
        acceptButton.Click += clickActions[i];
        someList.Items.Add(acceptButton);
    }     
