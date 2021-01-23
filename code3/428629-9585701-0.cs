    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 100; i++)
        { 
            Person p = new Person { FirstName = "John", LastName = "Doe", ID = Guid.NewGuid().ToString()};
            listBox1.Items.Add(p);
        }
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        MessageBox.Show(((Person)listBox1.SelectedItem).ID);
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public override string ToString()
        {
            return LastName + ", " + FirstName + " - " + ID;
        }
    }
