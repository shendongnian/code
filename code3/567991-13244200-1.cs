    class StudentList : List<Student>, ICloneable
    {
        public object Clone ()
        {
            StudentList oNewList = new StudentList ();
            for ( int i = 0; i < Count; i++ )
            {
                oNewList.Add ( this[i].Clone () as Student );
            }
            return ( oNewList );
        }
    }
