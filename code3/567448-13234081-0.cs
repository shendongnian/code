	void ChooseHyperExecute(object param)
	{
		SampleViewModel dt = param as SampleViewModel;
		string ma = dt.String_Value;			
		var externalUri = new Uri(Application.Current.Host.Source, 
            string.Format("./Images/{0}", ma));
		var absoluteUri = new Uri(externalUri, UriKind.Absolute);
		System.Windows.Browser.HtmlPage.Window.Navigate(absoluteUri, "_blank");
	}
