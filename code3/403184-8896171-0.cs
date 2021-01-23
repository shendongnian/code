    public class Foo
    {
      public string Item { get; set; }
    }
    
    private void Form2_Load(object sender, EventArgs e)
     {
      List<Foo> list = new List<Foo>()
          {
           new Foo() { Item="1" },
           new Foo() { Item="2" }
       };
    
      dataGridView1.DataSource = list;
      textBox1.DataBindings.Add("Text", list, "Item");
    }
            
