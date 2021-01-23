    class NameComparer: IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if(x.Name < y.Name)
                return -1;
            else if (x.Name == y.Name)
                return 0;
            else
                return 1;
        }
    }
