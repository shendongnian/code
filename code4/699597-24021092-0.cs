    protected override void OnPreRender(EventArgs e)
		{
			string text = this.ImageUrl;
			if (this.TemplateImageUrl != null)
			{
				text = this.TemplateImageUrl;
			}
			if (this.LoadedImageUrl != text)
			{
				Uri requestUri = new Uri(HttpContext.Current.Request.Url, base.ResolveClientUrl(text));
				try
				{
					using (WebResponse response = WebRequest.Create(requestUri).GetResponse())
					{
						System.Drawing.Image image = System.Drawing.Image.FromStream(response.GetResponseStream());
						this.Width = image.Width;
						this.Height = image.Height;
						this.LoadedImageUrl = text;
					}
				}
				catch (Exception)
				{
				}
			}
			base.OnPreRender(e);
		}
