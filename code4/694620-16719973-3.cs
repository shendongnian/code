    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    System.Diagnostics.Debug.WriteLine(iPeople.Count().ToString());
    System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds.ToString());  // 13 ms
    sw.Restart();
    ObservableCollection<Person> ocPeople = new ObservableCollection<Person>(iPeople);         
    System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds.ToString());  // 16 ms
    sw.Restart();
    System.Diagnostics.Debug.WriteLine(iPeople.Count().ToString());
    System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds.ToString());  //  8 ms
    sw.Restart();
    System.Diagnostics.Debug.WriteLine(ocPeople.Count().ToString());
    System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds.ToString());  //  1 ms
    sw.Restart();
    List<Person> lPeople = new List<Person>(iPeople);
    System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds.ToString());  // 10 ms
    sw.Restart();
    ObservableCollection<Person> ocPeople2new = new ObservableCollection<Person>(lPeople);
    System.Diagnostics.Debug.WriteLine(sw.ElapsedMilliseconds.ToString());  //  6 ms
    
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
 
