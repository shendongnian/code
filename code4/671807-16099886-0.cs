       public void MouseClick(object sender, MouseButtonEventArgs e) {
          var objDataContext = (IContentItem)this.DataContext;
          var Screen = (Microsoft.LightSwitch.Client.IScreenObject)objDataContext.Screen;
         
          Screen.Details.Dispatcher.BeginInvoke(() => {
            Screen.Details.Methods["DoImageLinkEvent"]
                  .CreateInvocation(null).Execute();
          });
        } 
