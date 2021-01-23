    class MyType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return Description;
        }
    }
    var selectedObject = cb.Items.Cast<MyType>().SingleOrDefault(i => i.Id.Equals(myId));
