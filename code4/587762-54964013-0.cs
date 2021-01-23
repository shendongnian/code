    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
	// ...
	
	var people = new List<Person>() { /* Add some data */ };
	comboBox1.DisplayMember = "Name";
	comboBox1.ValueMember = "Id";
	comboBox1.DataSource = people;
	
	// ...
	
	bool exists = comboBox1.Items.OfType<Person>().Any(p => p.Id == 1);
