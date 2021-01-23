        public void MapListOfPeopleWithSameHouse()
        {
            Mapper.CreateMap<Person, PersonDTO>();
            Mapper.CreateMap<House, HouseDTO>();
            var people = new List<Person>();
            var house = new House() { Address = "123 Main" };
            people.Add(new Person() { Name = "John", Houses = new List<House>() { house } });
            people.Add(new Person() { Name = "Will", Houses = new List<House>() { house } });
            var peopleDTO = Mapper.Map<List<Person>>(people);
            Assert.IsNotNull(peopleDTO[0].Houses);
            Assert.AreSame(peopleDTO[0].Houses[0], peopleDTO[1].Houses[0]);
        }
