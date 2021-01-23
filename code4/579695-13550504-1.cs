    public class Person {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<Order> Orders { get; set; } 
    }
    public class Good {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class Order {
        public int Id { get; set; }
        public Person Person { get; set; }
        public Good Good { get; set; }
        public int Count { get; set; }
    }
    public class MyDbContext: DbContext
    {
        public IDbSet<Person> Persons { get { return Set<Person>(); }}
        public IDbSet<Good> Goods { get { return Set<Good>(); }}
        public IDbSet<Order> Orders { get { return Set<Order>(); }} 
    }
    public class PersonRepository {
        public IEnumerable<Person> GetAll() {
            using (var context = new MyDbContext()) {
                return context.Persons.ToList();
            }
        }
        public IEnumerable<Person> GetLastWeekPersons() {
            using (var context = new MyDbContext()) {
                return context.Persons.Where(p => p.RegistrationDate > new DateTime().AddDays(-7)).ToList();
            }
        } 
        public Person GetById(int id, MyDbContext context) {
            return context.Persons.Include(p => p.Orders).FirstOrDefault(p => p.Id == id);
        }
        public Person GetById(int id) {
            using (var context = new MyDbContext()) {
                return GetById(id, context);
            }
        }
    }
    public class PersonWrap {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int OrderCount { get; set; }
        public PersonWrap(Person person) {
            Id = person.Id;
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            OrderCount = person.Orders.Count;
        }
        public void Update(Person person) {
            person.FirstName = FirstName;
            person.SecondName = SecondName;
        }
    }
    public class PersonDetailsViewController {
        public PersonWrap Person { get; protected set; }
        public PersonDetailsViewController(int personId) {
            var person = new PersonRepository().GetById(personId);
            if (person != null) {
                Person = new PersonWrap(person);
            }
        }
        public void Save() {
            using (var context = new MyDbContext()) {
                var person = new PersonRepository().GetById(Person.Id, context);
                Person.Update(person);
                context.SaveChanges();
            }
        }
    }
