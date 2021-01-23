        [Serializable]
        public class C2 : C1
        {
            public bool IsValid_C2 { get; set; }
            [XmlIgnore]
            public override bool IsValid_C1 { get; set; }
            public C2()
            {
                IsValid_C1 = true;
                IsValid_C2 = false;
            }
        }
