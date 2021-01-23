             String url = NavigationContext.QueryString["url"];
             if(url!=_oldUrl)
             {
                  if (!String.IsNullOrEmpty(url))
                  {
                         browser.Navigate(new Uri(url));
                  }
             }
        }
