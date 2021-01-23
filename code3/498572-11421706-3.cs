    //Assuming person is detached from the context
    //for both examples
    public class Person
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public DateTime BornOn { get; set; }   
    }
    public void UpdatePerson(Person person)
    {
      this.Context.Persons.Attach(person)
      DbEntityEntry<Person> entry = Context.Entry(person);
      entry.State = System.Data.EntityState.Modified;
      Context.SaveChanges();
    }
