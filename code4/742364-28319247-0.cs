		private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (!(e.Url.ToString().Equals("about:blank", StringComparison.InvariantCultureIgnoreCase)))
			{
				System.Diagnostics.Process.Start(e.Url.ToString());
				e.Cancel = true;
			}
		}
