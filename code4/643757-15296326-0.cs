    class MyDerivedClass : Clazz
    {
        public string Text;
        private List<MyNestedClass> _list;
        public override void CopyFrom(Clazz source)
        {
            var src = source as MyDerivedClass;
            if (src == null) return;
            Text = src.Text;
        }
        public List<Clazz> GetAllItems()
        {
            var list = new List<Clazz>();
            list.Add(this);
            list.AddRange(_list);
            return list;
        }
        class MyNestedClass : Clazz
        {
            public int Number;
            public override void CopyFrom(Clazz source)
            {
                var src = source as MyNestedClass;
                if (src == null) return;
                Number = src.Number;
            }
        }
    }
