    public class SampleModule : Nancy.NancyModule 
    {
        public SampleModule()
        {
            Get["/GetHOSports"] = parameters => {
                Response.ContentType = "application/json"
                Response.Content = s => {
                    var sw = new StreamWriter(s) { AutoFlush = true };
                    sw.Write("your json here");
                }
            }
        }
    }
