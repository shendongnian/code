    [Serializable]
    public abstract class BaseClass
    {
        public string Name { get; set; }
    
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
    
    public class DerivedClass : BaseClass
    {
        public int Age { get; set; }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            var derivedClass = new DerivedClass { Name = "Test", Age = 10 };
            derivedClass.CanExecuteChanged += (sender, eventArgs) => Console.WriteLine("hello");
    
            var serializer = new DataContractSerializer(typeof(DerivedClass));
            using (var stream = new FileStream("d:\\test.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                serializer.WriteObject(stream, derivedClass);
            }
        }
    }
