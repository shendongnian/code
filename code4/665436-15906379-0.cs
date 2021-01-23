        [DataContract]
        public class DocumentHolder
        {
            [DataMember(Name = "Documents")]
            public Documents Document { get; set; }
        }
        [DataContract]
        public class Documents
        {
            [DataMember(Name = "Title", Order = 1)]
            public string Title { get; set; }
            [DataMember(Name = "DatePublished", Order = 2)]
            public DateTime? DatePublished { get; set; }
            [DataMember(Name = "DocumentURL", Order = 3)]
            public string DocumentURL { get; set; }
            [DataMember(Name = "ThumbnailURL", Order = 4)]
            public string ThumbnailURL { get; set; }
            [DataMember(Name = "Abstract", Order = 5)]
            public string Abstract { get; set; }
            [DataMember(Name = "Sector", Order = 6)]
            public string Sector { get; set; }
            [DataMember(Name = "Country", Order = 7)]
            public List<string> Country { get; set; }
            [DataMember(Name = "Document Type", Order = 8)]
            public string DocumentType { get; set; }
            public Documents()
            {
                this.Country = new List<string>();
            }
        }
