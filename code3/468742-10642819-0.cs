    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    namespace MyNamespace
    {
       [DataContract]
       public class TwitterObject
       {
          [DataMember(Name = "statuses")]
          public TwitterStatus[] Statuses { get; set; }
       }
       [DataContract]
       public class TwitterStatus
       {
           [DataMember(Name = "in_reply_to_status_id_str")]
           public string InReplyToStatusIdStr { get; set; }
           [DataMember(Name = "id_str")]
           public string IdStr { get; set; }
       }
    }
