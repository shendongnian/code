       	foreach (Control c in panel1.Controls)
	{
		if (c is WebBrowser)
		{
			panel1.Controls.Remove(c);
		}
	}
	WebBrowser wbYoutube = new WebBrowser();
	wbYoutube.Url = new Uri("http://www.youtube.com/embed/" + datagridview1[0, e.RowIndex].Value.ToString() + "?autoplay=1");
	panel1.Controls.Add(wbYoutube);
