    using System;
    using System.Collections;
    public class Person : IComparable<Person>
    {
        #region Private Members
        private string _firstname;
        private string _lastname;
        private int _age;
        #endregion
        #region Properties
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        #endregion
        #region Contructors
        public Person (string firstname, string lastname, int age)
        {
            _firstname = firstname;
            _lastname = lastname;
            _age = age;
        }
        #endregion
        public override string ToString()
        {
            return String.Format(“{0} {1}, Age = {2}“, _firstname,
                 _lastname, _age.ToString());
        }
        #region IComparable Members
        public int CompareTo(Person obj)
        {
            return _firstname.CompareTo(p2.Firstname);
        }
        #endregion
    }
