            var basicUriString   = String.Format("/{0}.Base;component/Basic.xaml", skinName);
            try
            {
                var uri = new Uri(basicUriString, UriKind.RelativeOrAbsolute);
                newDict = new ResourceDictionary { Source = uri };
                if (!Application.Current.Resources.MergedDictionaries.Any(dic => dic.Source.OriginalString.Contains(basicUriString)))
                {
                    Application.Current.Resources.MergedDictionaries.Add(newDict);
                }
            }
            catch (Exception e)
            {
                // log error
            }
