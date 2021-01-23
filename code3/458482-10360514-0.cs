    [MetadataType(typeof(customerSurveyMetadata))]
    public partial class customerSurvey {
        private sealed class customerSurveyMetadata {
            public string Name { get; set; }
        }
        public override string ToString() {
            return Name;
        }
    }
