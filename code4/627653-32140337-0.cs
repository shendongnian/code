    You can use this Example:
    
    public Void HideAllControl()
    { 
       /// casting the content into panel
               Panel mainContainer = (Panel)this.Content;
               /// GetAll UIElement
               UIElementCollection element = mainContainer.Children;
               /// casting the UIElementCollection into List
               List < FrameworkElement> lstElement =    element.Cast<FrameworkElement().ToList();
    
               /// Geting all Control from list
               var lstControl = lstElement.OfType<Control>();
               foreach (Control contol in lstControl)
               {
                   ///Hide all Controls 
                   contol.Visibility = System.Windows.Visibility.Hidden;
               }
    }
