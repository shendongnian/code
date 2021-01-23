    var client = new HttpClient();
    string url = Request.Url.GetLeftPart(UriPartial.Authority) + "/api/GetBatches";
    var result = client.GetAsync(url).Result;
    var content = result.Content;
    var model = content.ReadAsAsync<IEnumerable<MyViewModel>>().Result;
    if (model == null) return View();
    else return View(model);
