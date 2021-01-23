	protected override void StartScan( string url )
		{
			WebBrowser browser = new WebBrowser();
			int i = 1;
			Thread thread = new Thread( () =>
			{
				WebBrowserDocumentCompletedEventHandler documentCompleted = null;
				documentCompleted = async ( o, s ) =>
				{
					if ( i < 27 )
					{
						HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
						document.LoadHtml(browser.DocumentText);
						List<Establishment> establishments = GetEstablishments(document).ToList();
						SaveResults(establishments);
						string var = i < 10 ? "0" + i.ToString(CultureInfo.InvariantCulture) : i.ToString(CultureInfo.InvariantCulture);
						browser.Navigate( string.Format( "javascript:__doPostBack('SchoolDirectoryWebPart1$ctl{0}','')", var ) );
						i++;
					} else {
						browser.Dispose();
						Application.ExitThread();
					}
				};
				browser.ScriptErrorsSuppressed = true;
				browser.DocumentCompleted += documentCompleted;
				browser.Url = new Uri(url);
				browser.Navigate( "javascript:__doPostBack('SchoolDirectoryWebPart1$ctl01','')" );
				Application.Run();
			} );
			thread.SetApartmentState( ApartmentState.STA );
			thread.Start();
		}
