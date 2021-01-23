    @using (var webClient = new System.Net.WebClient())
    {
      string json = webClient.DownloadString(String.Format(
      "https://cloud.51degrees.com/api/v1/{0}/match?user-agent=
    {1}&values=DeviceType",
      "YOUR KEY HERE",
      HttpUtility.UrlEncode(Request.UserAgent)));
    dynamic match = Newtonsoft.Json.Linq.JObject.Parse(json);
      SortedList<string, string[]> values = Newtonsoft.Json.JsonConvert.DeserializeObject<SortedList<string, string[]>>(match.Values.ToString());
      string[] hvValues;
     if (values.TryGetValue("DeviceType", out hvValues))
      {
    foreach (string s in hvValues)
    {
	<h4>
		Device Type:
		@s
	</h4>
    }
      }
