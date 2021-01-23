    public class Person
    {
      internal Person(XElement personElement)
      {
        this.FirstName = personElement.Element("first_name").Value;
        this.LastName = personElement.Element("last_name").Value;
    
        this.Jobs = new List<Job>();
        foreach (var jobElement in personElement.Elements("jobs"))
        {
          this.Jobs.Add(new Job(jobElement));
        }
      }
    
      internal Person(string firstName, string lastName, ICollection<Job> jobs)
      {
         //set properties
      }
    
      public string FirstName {get; private set;}
      public string LastName {get; private set;}
      public ICollection<Job> {get; private set;}
    }
