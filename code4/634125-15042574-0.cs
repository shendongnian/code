    class Program
        {
            private static void Main(string[] args)
            {
                Mapper.CreateMap<CustomerDto, CustomerDomainModel>()
                        .ForMember(d => d.Id, opt => opt.Ignore())
                          .ConstructUsing((Func<ResolutionContext, CustomerDomainModel>) (rc => DataBindingFactory.Create<CustomerDomainModel>()));
    
                var dto = new CustomerDto {FirstName = "First", LastName = "Last"};
                var domain = Mapper.Map<CustomerDto, CustomerDomainModel>(dto);
                Console.WriteLine("First: " + domain.FirstName);
                Console.WriteLine("Last: " + domain.LastName);
                Console.ReadLine();
            }
        }
    
        public class CustomerDto
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    
        public class CustomerDomainModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    
        public static class DataBindingFactory
        {
            public static T Create<T>()
            {
                return Activator.CreateInstance<T>();
            }
        }
