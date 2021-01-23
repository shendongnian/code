    class PersonViewModel
    {
        private Person OriginalModel { get; set; }
        public ValueViewModel<string> Name { get; set; }
        public ValueViewModel<int> Postcode { get; set; }
        protected void ReadFromModel(Person person)
        {
            OriginalModel = person;
            Name.Value = OriginalModel.Name;
            Postcode.Value = OriginalModel.Postcode;
        }
        protected Person WriteToModel()
        {
            OriginalModel.Name = Name.Value; //...
            return OriginalModel;
        }
    }
