    public class Car
    {
        public string IdLang { get; set; }
        public string IdCompany { get; set; }
    }
    public partial class Form1: UserControl
    {
        List<Car> EnglishCars;
        public Form1()
        {
            InitializeComponents();
            EnglishCars= new List<Car>{ 
              new Car { IdLang = "EN", IdCompany = "SomeCompany"},
              new Car { IdLang = "EN", IdCompany = "SomeOtherCompany"}
        }
    
    }
    
    public partial class Form2: UserControl
    {
        List<Car> OtherCars;
        public Form1()
        {
            InitializeComponents();
            OtherCars= new List<Car>{ 
              new Car { IdLang = "DE", IdCompany = "SomeCompany"},
              new Car { IdLang = "DE", IdCompany = "SomeOtherCompany"}
        }
    
    }
