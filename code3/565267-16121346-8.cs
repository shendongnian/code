    private static void SerializePerson(Person person)
    {
        if (person == null)
            throw new ArgumentNullException("person");
    
        using (var memoryStream = new MemoryStream())
        {
            //Configure our surrogate selectors.
            var surrogateSelector = new SurrogateSelector();
            surrogateSelector.AddSurrogate(typeof (Person), new StreamingContext(StreamingContextStates.All),
                                           new PersonSurrogate());
            surrogateSelector.AddSurrogate(typeof (DriversLicense), new StreamingContext(StreamingContextStates.All),
                                           new DriversLicenseSurrogate());
    
            //Serialize the object
            IFormatter formatter = new BinaryFormatter();
            formatter.SurrogateSelector = surrogateSelector;
            formatter.Serialize(memoryStream, person);
    
            //Return to the beginning of the stream
            memoryStream.Seek(0, SeekOrigin.Begin);
    
            //Deserialize the object
            Person deserializedPerson = (Person) formatter.Deserialize(memoryStream);
        }
    }
