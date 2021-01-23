When you add the UICommand you have to set additional properties, like :
    private async void AddTaskButtonClick(object sender, RoutedEventArgs e)
    {
        PopupMenu menu = new PopupMenu();
        menu.Commands.Add(new UICommand
                              {
                                  Id = 1,
                                  Label = "Everyday Task",
                                  Invoke = DoTasks 
                              });  
        menu.Commands.Add(new UICommand
                              {
                                  Id = 2,
                                  Label = "Onetime Task",
                                  Invoke = DoTasks 
                              });             
        menu.Commands.Add(new UICommand("Onetime Task"));
        await menu.ShowAsync(new Point(10,680));
    }
