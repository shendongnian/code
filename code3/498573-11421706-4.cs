    public void UpdatePersonNameOnly(Person person)
    {
      this.Context.Persons.Attach(person)
      DbEntityEntry<Person> entry = Context.Entry(person);
      entry.Property(e => e.Name).IsModified = true;
      Context.SaveChanges();
    }
