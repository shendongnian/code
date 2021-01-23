    public class PersonSurrogate : ISerializationSurrogate
    {
        /// <summary>
        /// Manually add objects to the <see cref="SerializationInfo"/> store.
        /// </summary>
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Person person = (Person) obj;
            info.AddValue("Name", person.Name);
            info.AddValue("Age", person.Age);
            info.AddValue("License", person.License);
        }
    
        /// <summary>
        /// Retrieves objects from the <see cref="SerializationInfo"/> store.
        /// </summary>
        /// <returns></returns>
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Person person = (Person)obj;
            person.Name = info.GetString("Name");
            person.Age = info.GetInt32("Age");
            person.License = (DriversLicense) info.GetValue("License", typeof(DriversLicense));
            return person;
        }
    }
    
    public class DriversLicenseSurrogate : ISerializationSurrogate
    {
        /// <summary>
        /// Manually add objects to the <see cref="SerializationInfo"/> store.
        /// </summary>
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            DriversLicense license = (DriversLicense)obj;
            info.AddValue("Number", license.Number);
        }
    
        /// <summary>
        /// Retrieves objects from the <see cref="SerializationInfo"/> store.
        /// </summary>
        /// <returns></returns>
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            DriversLicense license = (DriversLicense)obj;
            license.Number = info.GetString("Number");
            return license;
        }
    }
