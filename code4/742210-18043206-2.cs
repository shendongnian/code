When you add the UICommand you have to set additional properties, like in the code below. I have taken advantage of your code, and modified a little also on the matter of positioning the PopUpMenu at calculated coordinates :) like below :
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
        //Determine position of where to show the PopUp :
        var pointTransform = ((Button) sender).TransformToVisual(Window.Current.Content);
        var screenCoords = pointTransform.TransformPoint(new Point(50, 10)); 
        //50, 10 are Horizontal and Vertical offsets, you should customize them as you wish.            
        
        await menu.ShowAsync(screenCoords);
    }
Afterwards, you will need the DoTasks method :
    private void DoTasks(IUICommand command)
    {
        var currentId = (int) command.Id;
        switch(currentId)
        {
            case 1 :
            {
            //your Everyday Task code here
            }
            case 2 :
            {
            //your OneTime Task code here
            }
        }
    }
You could also use, different Invoke - that would mean, using two different methods.
