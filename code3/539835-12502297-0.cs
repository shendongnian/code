    class FileType
    {
        public int MyProperty { get; set; }
    }
    class MFileType : FileType
    {
        public int MyProperty2 { get; set; }
    }
    
    class Class1
    {
        public string Id { get; set; }
        public MFileType DefaultFileType { get; set; }
    }
    class Class2
    {
        public string Id { get; set; }
        public virtual FileType DefaultFileType { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapper.Mapper.CreateMap<Class1, Class2>()
                .ForMember(dest => dest.DefaultFileType, opt => opt.MapFrom(src => src.DefaultFileType));
            
            var class1 = new Class1() { Id = "class1", DefaultFileType = new MFileType() { MyProperty = 1, MyProperty2 = 2 } };
            var class2 = AutoMapper.Mapper.Map<Class2>(class1);
            
            Console.WriteLine("class2.Id = " + class2.Id);
            // If below it says "False", it mapped correctly
            Console.WriteLine("class2.DefaultFileType == null = " + class2.DefaultFileType == null);
            
            Console.ReadLine();
        }
    }
