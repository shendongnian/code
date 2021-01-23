    //...
        gridControl1.DataSource = new BindingList<Person>();
        gridView1.Columns["ID"].Visible = false;
    }
    //...
    class Person {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
