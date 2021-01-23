    [DataContract]
    public class BitbucketResponse
    {
        [DataMember(Name="user")]
        public BitbucketUser User { get; set; }
    }
    [DataContract]
    public class BitbucketUser
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }
        // etc.
    }
    …
    var serializer = new DataContractJsonSerializer(typeof(BitbucketResponse));
    using (var stream = …)
    {
        var response = (BitbucketResponse)serializer.ReadObject(stream);
        var user = response.User;
    }
