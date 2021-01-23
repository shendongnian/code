    public class MyWindow: Window
    	{
            public MyWindow()
            {
                SetResources();                
            }
    
            private void SetResources()
            {
                DependencyObject dependencyObject;
                object temp;
    
                    temp = this.TryFindResource("MyResourceKey");
    
                    if (temp != null)
                    {
                        if (temp is DependencyObject)
                        {
                            dependencyObject = (DependencyObject)temp;
                            if (!dependencyObject.CheckAccess())
                            {
                                dependencyObject.Dispatcher.BeginInvoke(new System.Action(() => { this.SetResources(); }));
                            }
                            else
                            {
                                this.SetValue(BackgroundProperty, temp);                            
                            }
                        }                   
                    }
              }                  
    	}
