        [XmlIgnore]
        public float? Speed { get; set; }
        [XmlAttribute("Speed")]
        public float SpeedSerializable
        {
            get
            {
                return this.Speed.Value;
            }
            set { this.Speed = value; }
        }
        public bool ShouldSerializeSpeedSerializable()
        {
              return Speed.HasValue;
        }
