    public class MyClass
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        List<MyClass> lstContacts = new List<MyClass>();
        //need to add items to list
        lstContacts.Add(new MyClass() { Id = 1, Email = "def@gmail.com" }); 
        lstContacts.Add(new MyClass() { Id = 2, Email = "def@gmail.com" });
        lstContacts.Add(new MyClass() { Id = 3, Email = "ghi@gmail.com" });
        
        dataGridView1.DataSource = lstContacts;
        dataGridView1.Show();
        
     }
