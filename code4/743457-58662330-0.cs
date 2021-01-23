    class PersonModel
    {
        [Selector("#BirdthDate")]
        [Converter(typeof(DateTimeConverter))]
        public DateTime BirdthDate { get; set; }
    }
    // ...
    
    PersonModel person = WebContentParser.Parse<PersonModel>(html);
