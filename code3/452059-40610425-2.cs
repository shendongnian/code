    public class PersonConfig : ExtendedXmlSerializerConfig<Person>
    {
        public PersonConfig()
        {
            Encrypt(p => p.Password);
        }
    }
