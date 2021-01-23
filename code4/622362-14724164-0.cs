        public Dictionary<int, dynamic> specialties = new Dictionary<int, dynamic>();
        public Dictionary<int, dynamic> SpecialtyLists()
        {
            specialties.Add(1, new {name = "Varun", age = "11"} );
            specialties.Add(2, new {name = "Khushi", age = "12"} );
            return (specialties);
        }
    }
