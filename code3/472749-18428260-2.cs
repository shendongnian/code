    protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                try
                {
                    string selectedItem= "";
                    if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedItem))
                    {
                        if(null != selectedItem) {
                        // your code
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
