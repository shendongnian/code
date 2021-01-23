     [DataContract]
        [KnownType(typeof(ActivityDC))]
        [KnownType(typeof(StepDC))]
        [KnownType(typeof(WaveDC))]
        public class CampaignDC : AuditedEntityBaseDC
        {
            [DataMember]
            public IList<IActivityDC> Activities { get; set; }
