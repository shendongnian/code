    public class Person
    {
        public String Name;
        public int Age;
        public List<string> EmailAddresses = new List<string>();
    
        public void Add(string email)
        {
            EmailAddresses.Add(email);
        }
    }
    [Test]
    public void Noodling()
    {
            IGenerationSessionFactory factory = AutoPocoContainer.Configure(x =>
        {
            x.Conventions(c => { 
                c.UseDefaultConventions();
            });
            x.AddFromAssemblyContainingType<LegacyUserProfileDto>();
    
            x.Include<Person>()
                .Setup(p => p.Name).Use<FirstNameSource>()
                .Invoke(z => z.Add(Use.Source<string, EmailAddressSource>()));
            //.Invoke(z => z.EmailAddresses.Add(Use.Source<string, EmailAddressSource>()));//Fails
        });
        IGenerationSession session = factory.CreateSession();
    
        Person person = session.Single<Person>().Get();
        Console.WriteLine(person.Age + " " + person.Name);
        foreach (string emailAddress in person.EmailAddresses)
        {
            Console.WriteLine(emailAddress);    
        }
    }
