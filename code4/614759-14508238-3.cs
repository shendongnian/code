    var distinctUrls = urls.GroupBy (u =>
        {
            var uri = new Uri(u);
            var query = HttpUtility.ParseQueryString(uri.Query);
            var baseUri = uri.Scheme + "://" + uri.Host + uri.AbsolutePath;
            return new {
                Uri = baseUri,
                QueryStringKeys = string.Join("&", query.AllKeys.OrderBy (ak => ak))
            };
        })
        .Select (g => g.First())
        .ToList();
