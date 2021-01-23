	public class Person
	{
		public String Name { get; set; }
		public String Gender { get; set; }
	}
    // Your control
    private List<Person> _persons = new List<Person>();
 
    // Click Event
    dataGridView1.DataSource = null;
    _persons.Add(new Person() { Name = "Test", Gender = "Male" });
    dataGridView1.DataSource = _persons;
