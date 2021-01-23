    public static void ChangeAppLanguage(string CultureName)
        {
            App.RootFrame.Language = XmlLanguage.GetLanguage(CultureName);
            FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
            App.RootFrame.FlowDirection = flow;
            App.Current.RootVisual.UpdateLayout();
            App.RootFrame.UpdateLayout();
            var ReloadUri =( App.RootFrame.Content as PhoneApplicationPage).NavigationService.CurrentSource;
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri(ReloadUri + "?no-cache=" + Guid.NewGuid(), UriKind.Relative));
        }
