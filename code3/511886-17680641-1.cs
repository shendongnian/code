    public class SampleConverter<T> : CustomCreationConverter<ISample> where T: new ()
    {
        public override ISample Create(Type objectType)
        {
            return ((ISample)new T());
        }
    }
