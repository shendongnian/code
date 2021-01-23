    class MyCollection : ObservableCollection<MyObject> 
    {  
        public void Add(string prop1, string prop2)
        {
            base.Add(new MyObject { Prop1 = prop1, Prop2 = prop2 });
        }
    }
