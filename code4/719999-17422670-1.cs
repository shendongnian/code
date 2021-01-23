    class Program
        {
            static void Main(string[] args)
            {
                var model = new Model { Count = 123, Date = DateTime.Now, Name = "Some name" };
    
                Mapper.CreateMap<Model, FacadeForModel>();
                var mappedObject = AutoMapper.Mapper.Map<FacadeForModel>(model);
    
                Console.WriteLine(mappedObject);
    
                Console.ReadLine();
            }
    
            class Model
            {
                public string Name { get; set; }
    
                public DateTime Date { get; set; }
    
                public int Count { get; set; }
            }
    
            interface INavigationItem
            {
                int Id { get; set; }
    
                string OtherProp { get; set; }
            }
    
            class FacadeForModel : Model, INavigationItem
            {
                public int Id { get; set; }
    
                public string OtherProp { get; set; }
            }
        }
