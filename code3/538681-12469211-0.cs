        [DataContract]
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Status
        {
            [EnumMember(Value = "NOT_ADMITTED")]
            [Description("NOT_ADMITTED")]
            NotAdmitted,
            [EnumMember(Value = "ADMITTED")]
            [Description("ADMITTED")]
            Admitted
        }
