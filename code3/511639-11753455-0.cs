    public class ApplicationFieldConverter : CustomCreationConverter<IApplicationField>
    {
        public override IApplicationField Create(Type objectType)
        {
            return new FakeApplicationField();
        }
    }
