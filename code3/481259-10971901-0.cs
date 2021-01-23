    public class Name 
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int ID { get; set; }
    
        public string Name_Forename { get; set; }
    
        public string Name_Surname { get; set; }
    
        public string GetFullName()
        {
            return Name_Forename + ' ' + Name_Surname;
        }
    }
    
    
    public class Contact
    {
        public int ID { get; set; }
    
        public Name Name { get; set; }
    
        public string Contact_Landline { get; set; }
    
        public string Contact_Mobile { get; set; }
    
        public string Contact_Email { get; set; }
    }
    
    public class NameViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int ID { get; set; }
    
        public string Name_Forename { get; set; }
    
        public string Name_Surname { get; set; }
    
    }
    
    public class ContactViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int ID { get; set; }
    
        public NameViewModel Name { get; set; }
    
        public string Contact_Landline { get; set; }
    
        public string Contact_Mobile { get; set; }
    
        [DataType(DataType.EmailAddress)]
        public string Contact_Email { get; set; }
    }
    
    
    class Program
    {
        static void Main()
        {
            Mapper.CreateMap<Name, NameViewModel>();
            Mapper.CreateMap<Contact, ContactViewModel>();
    
            var contact = new Contact
            {
                Name = new Name
                {
                    Name_Forename = "forename"
                }
            };
            var vm = Mapper.Map<Contact, ContactViewModel>(contact);
            Console.WriteLine(vm.Name.Name_Forename);
        }
    }
