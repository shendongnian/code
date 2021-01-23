    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    System.Diagnostics.Debug.WriteLine(iPeople.Count().ToString());
    System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds.ToString());
    sw.Restart();
    ObservableCollection<Person> ocPeople = new ObservableCollection<Person>(iPeople);         
    System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds.ToString());
    
    public IEnumerable<Person> iPeople
    {
        get
        {
            for (int i = 0; i < 100000; i++) yield return new Person(i);
        }
    }
    
    public class Person
    {
        public Int32 ID { get; private set; }
        public Person(Int32 id) { ID = id; }
    } 
 
