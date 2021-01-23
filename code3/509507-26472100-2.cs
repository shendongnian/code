    // POST: api/People
      public IHttpActionResult Post(Models.Person personDto)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var person = new Entities.Person
                         {
                                 FirstName = personDto.FirstName,
                                 LastName = personDto.LastName,
                                 DateOfBirth = personDto.DateOfBirth,
                                 PreferedLanguage = personDto.PreferedLanguage
                         };
            _db.Persons.Add(person);
            _db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = person.Id }, personDto);
        }
