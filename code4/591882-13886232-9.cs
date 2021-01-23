    using System.ComponentModel;
    
    namespace WpfApplication
    {
        public class Person : ObservableObject
        {
            private string name;
            private string surname;
            private char gender;
    
            public string Name
            {
                get { return this.name; }
                set { this.SetValue(ref this.name, value, "Name"); }
            }
    
            [Editable(AllowEdit = false)]
            public string Surname
            {
                get { return this.surname; }
                set { this.SetValue(ref this.surname, value, "Surname"); }
            }
    
            [NameValue(Name = "Male", Value = 'M')]
            [NameValue(Name = "Female", Value = 'F')]
            public char Gender
            {
                get { return this.gender; }
                set { this.SetValue(ref this.gender, value, "Gender"); }
            }
        }
    }
