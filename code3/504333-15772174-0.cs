        using System;
        using System.Collections.Generic;
        using Newtonsoft.Json;
        using System.Runtime.Serialization;
        using System.IO;
        using System.Runtime.Serialization.Json;
        using System.Text;
        namespace LUM_Win.model
        {
            [DataContract]
            public class User
            {
                public User() { }
                public User(String JSONObject)
                {
                    MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(JSONObject));
                    DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(User));
                    User user = (User)dataContractJsonSerializer.ReadObject(stream);
                    this.ID = user.ID;
                    this.Country = user.Country;
                    this.FirstName = user.FirstName;
                    this.LastName = user.LastName;
                    this.Nickname = user.Nickname;
                    this.PhoneNumber = user.PhoneNumber;
                    this.DisplayPicture = user.DisplayPicture;
                    this.IsRegistred = user.IsRegistred;
                    this.IsConfirmed = user.IsConfirmed;
                    this.VerificationCode = user.VerificationCode;
                    this.Meetings = user.Meetings;
                }
                [DataMember(Name = "_id")]
                [JsonProperty(PropertyName = "_id")]
                public String ID { get; set; }
                [DataMember(Name = "country")]
                [JsonProperty(PropertyName = "country")]
                public String Country { get; set; }
                [DataMember(Name = "firstname")]
                [JsonProperty(PropertyName = "firstname")]
                public String FirstName { get; set; }
                [DataMember(Name = "lastname")]
                [JsonProperty(PropertyName = "lastname")]
                public String LastName { get; set; }
                [DataMember(Name = "nickname")]
                [JsonProperty(PropertyName = "nickname")]
                public String Nickname { get; set; }
                [DataMember(Name = "number")]
                [JsonProperty(PropertyName = "number")]
                public String PhoneNumber { get; set; }
                [DataMember(Name = "thumbnail")]
                [JsonProperty(PropertyName = "thumbnail")]
                public String DisplayPicture { get; set; }
                [DataMember(Name = "registered")]
                [JsonProperty(PropertyName = "registered")]
                public bool IsRegistred { get; set; }
                [DataMember(Name = "confirmed")]
                [JsonProperty(PropertyName = "confirmed")]
                public bool IsConfirmed { get; set; }
                [JsonIgnore]
                [DataMember(Name = "verification_code")]
                public String VerificationCode { get; set; }
                [JsonIgnore]
                [DataMember(Name = "meeting_ids")]
                public List<Meeting> Meetings { get; set; }
                public String toJSONString()
                {
                    return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                }
            }
        }
