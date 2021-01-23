      class Person
    {
        public int ID { get; set; }
        public string FamilyName { get; set; }
        public Person(string file)
        {
            if (!File.Exists(file))
                return;
            string[] personData = File.ReadAllLines(file);
            foreach (var item in personData)
            {
                string[] itemPair = item.Split('='); //do some error checking here to see if = isn't appearing twice
                string itemKey = itemPair[0];
                string itemValue = itemPair[1];
                switch (itemKey)
                {
                    case "familyName":
                        this.FamilyName = itemValue;
                        break;
                    case "id":
                        this.ID = int.Parse(itemValue);
                        break;
                    default:
                        break;
                }
            }
        }
    }
