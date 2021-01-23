    var imageUrl = "~/Handler2.ashx?Id=" + empid;
    var baseUri = new Uri(Request.Url.GetLeftPart(UriPartial.Authority));
    var url = new Uri(baseUri, VirtualPathUtility.ToAbsolute(imageUrl));
    using (var client = new HttpClient())
    {
        var request = new HttpRequestMessage(HttpMethod.Head, url);
        var response = client.SendAsync(request).Result;
        if (response.IsSuccessStatusCode)
        {
            // the image exists:
            PageLinkButton.Text = "Update your Image";
            Image2.ImageUrl = imageUrl;
        }
        else
        {
            // the image does not exist:
            PageLinkButton.Text = "Add your Image";
        }
    }
