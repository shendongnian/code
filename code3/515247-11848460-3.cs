    		public static MvcHtmlString EmbeddedImage(this HtmlHelper htmlHelper, string imageName, dynamic htmlAttributes)
		{
			UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
			var anchor = new TagBuilder("img");
			anchor.Attributes["src"] = url.Action("GetEmbeddedResource", "Shared",
												  new
													  {
														  resourceName = "Namespace.Content.Images." + imageName,
														  pluginAssemblyName = url.Content("~/bin/Namespace.dll")
													  });
			if (htmlAttributes != null)
			{
				string width = "";
				string height = "";
				PropertyInfo pi = htmlAttributes.GetType().GetProperty("width");
				if (pi != null)
					width = pi.GetValue(htmlAttributes, null).ToString();
				pi = htmlAttributes.GetType().GetProperty("height");
				if (pi != null)
					height = pi.GetValue(htmlAttributes, null).ToString();
				if (!string.IsNullOrEmpty(height))
					anchor.Attributes["height"] = height;
				if (!string.IsNullOrEmpty(width))
					anchor.Attributes["width"] = width;
			}
			return MvcHtmlString.Create(anchor.ToString());
		}
