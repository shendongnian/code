        private void SetLanguageDictionary()
        {
             ResourceDictionary dict = new ResourceDictionary();
             switch (Thread.CurrentThread.CurrentCulture.ToString())
             { 
               case "en-US":
                 dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);
                 break;
               case "fr-CA":
                 dict.Source = new Uri("..\\Resources\\StringResources.fr-CA.xaml", UriKind.Relative);
                 break;
               default :
                 dict.Source = new Uri("..\\Resources\\StringResources.xaml",UriKind.Relative);
                 break;
             }
             this.Resources.MergedDictionaries.Add(dict);
        }
        
