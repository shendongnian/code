	this.PreRequestFilters.Add( (req, res) =>
		{
			const string queryString = "format=json"; 
			var jsonAccepted = req.AcceptTypes.Any(t => t.Equals(ContentType.Json, StringComparison.InvariantCultureIgnoreCase));
			var jsonSpecifiedOnQuerystring = !string.IsNullOrEmpty(req.QueryString["format"]) && req.QueryString["format"].Equals("json", StringComparison.InvariantCultureIgnoreCase);
			if (!jsonAccepted && !jsonSpecifiedOnQuerystring)
			{
			    var sb = new StringBuilder(req.AbsoluteUri);
				sb.Append(req.AbsoluteUri.Contains("?") ? "&" : "?");
				sb.Append(queryString);
				res.RedirectToUrl(sb.ToString(), HttpStatusCode.SeeOther);
				res.Close();
			}
		});
