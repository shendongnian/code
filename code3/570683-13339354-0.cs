        gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
        gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
        //...
        var bindingList = new BindingList<IPerson>(){
            new Person(){ Name="John", Age=23 },
            new Person(){ Name="Mary", Age=21 },
        };
        bindingList.AddingNew += bindingList_AddingNew; //  <<--
        bindingList.AllowNew = true;
        gridControl1.DataSource = bindingList;
    }
    
    void bindingList_AddingNew(object sender, AddingNewEventArgs e) {
        e.NewObject = new Person(); //   <<-- these lines did the trick
    }
    //...
    public interface IPerson {
        string Name { get; set; }
        int Age { get; set; }
    }
    class Person : IPerson {
        public string Name { get; set; }
        public int Age { get; set; }
    }
