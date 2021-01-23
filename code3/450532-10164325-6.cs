    public class Person : ObservableObject
    {
        private int age;
        private string name;
    
        public int Age
        {
            get { return this.age; }
            set { this.SetValue(ref this.age, value, "Age"); }
        }
    
        public string Name
        {
            get { return this.name; }
            set { this.SetValue(ref this.name, value, "Name"); }
        }
    }
