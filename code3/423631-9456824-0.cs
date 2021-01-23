    public class AtomFormatter : XmlMediaTypeFormatter
    {
        public AtomFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/atom+xml"));
        }
        protected override bool CanReadType(Type type)
        {
            return base.CanReadType(type) || type == typeof(Feed);
        }
    }
    var cli = new HttpClient();
    cli
        .GetAsync("http://stackoverflow.com/feeds/tag?tagnames=delphi&sort=newest")
        .ContinueWith(task =>
        {
            task.Result.Content.ReadAsAsync<Feed>(new[] { new AtomFormatter });
        }); 
