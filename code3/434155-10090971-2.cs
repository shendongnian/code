    [DataContract]
        public class AttachmentRequestDto
        {
             [DataMember]
             public string Title { get; set; }
             [DataMember]
             public string Description { get; set; }
             [DataMember]
             public string Filename { get; set; }
        }
