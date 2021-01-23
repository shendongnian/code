    class IDCompare : IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            return a.ID.CompareTo(b.ID);
        }
    }
