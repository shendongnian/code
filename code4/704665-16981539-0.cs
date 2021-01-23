    public class Departman {
        Person _p = new Person();
        public Person p {
            get { return _p; }
            set { _p = value; }
        }
        public string PersonName {
            get { return _p.PersonName; }
            set { _p = value.PersonName; }
        }
    }
