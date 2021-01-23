       public string Code { get; set; }
       public string Text { get; set; }
    }
    void PopulateGrid()
    {
        TestObject test1 = new TestObject()
        {
        Code = "code 1",
        Text = "text 1"
        };
        TestObject test2 = new TestObject()
       {
        Code = "code 2",
        Text = "text 2"
        };
        List<TestObject> list = new List<TestObject>();
        list.Add(test1);
        list.Add(test2);
        dataGridView1.DataSource = list; //THIS IS WHAT SHOULD DO IT
    }
