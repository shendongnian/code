     public class AddressResolver:ICivicAddressResolver
        {
            string language = "en-GB";
            public AddressResolver()
            {
    
            }
            public AddressResolver(string language)
            {
                this.language = language;
            }
            [DataContract]
            public class AddressInfo
            {
                [DataMember(Name = "formatted_address")]
                public string FormattedAddress { get; set; }
            }
            [DataContract]
            public class ResultInfo
            {
                [DataMember(Name = "results")]
                public AddressInfo[] Info { get; set; }
            }
            readonly string URITemplate = "http://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&sensor=true&language={2}";
            #region ICivicAddressResolver Members
    
            public CivicAddress ResolveAddress(GeoCoordinate coordinate)
            {
                throw new NotImplementedException("Use async version instead");
            }
    
            public void ResolveAddressAsync(GeoCoordinate coordinate)
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                client.DownloadStringCompleted += (s, e) =>
                {
                    if (e.Error == null)
                    {
                        var ainfo = ReadToObject<ResultInfo>(e.Result);
                        ResolveAddressCompleted(this, new ResolveAddressCompletedEventArgs(ToCivic(ainfo),e.Error,false,null));
                    }
                    else
                    {
                        ResolveAddressCompleted(this, new ResolveAddressCompletedEventArgs(new CivicAddress(), e.Error, false, null));
                    }
                };
                client.DownloadStringAsync(new Uri(GetFormattedUri(coordinate)));
            }
    
            private CivicAddress ToCivic(ResultInfo ainfo)
            {
                List<string> res = new List<string>();
                foreach (var single in ainfo.Info)
                {
                    res.Add(single.FormattedAddress);
                }
                if (res.Count > 0)
                    return new CivicAddress() { AddressLine1 = res[0] };
                else
                    return new CivicAddress() { AddressLine1 = "#UNKNOWN#" };
            }
    
            public event EventHandler<ResolveAddressCompletedEventArgs> ResolveAddressCompleted = delegate { };
    
            #endregion
            private string GetFormattedUri(GeoCoordinate coord)
            {
                return string.Format(CultureInfo.InvariantCulture, URITemplate, coord.Latitude, coord.Longitude,language);
            }
            public static T ReadToObject<T>(string json) where T : class
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                T res = ser.ReadObject(ms) as T;
                ms.Close();
                return res;
            }
        }
