    public class SampleConverter : CustomCreationConverter<ISample>
    {
        public override ISample Create(Type objectType)
        {
            return new Sample();
        }
    }
