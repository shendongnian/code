    //Assuming person is detached from the context
    //for both examples
    public void UpdatePerson(Person person)
    {
      this.Context.Persons.Attach(person)
      DbEntityEntry<Person> entry = Context.Entry(person);
      entry.State = System.Data.EntityState.Modified;
      Context.SaveChanges();
    }
    public void UpdatePersonNameOnly(Person person)
    {
      this.Context.Persons.Attach(person)
      DbEntityEntry<Person> entry = Context.Entry(person);
      entry.Property(e => e.Name).IsModified = true;
      Context.SaveChanges();
    }
