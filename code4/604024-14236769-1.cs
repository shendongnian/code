    namespace Model
    {
        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public class Class
        {
            public string Name { get; set; }
            public float Score { get; set; }
        }
    }
    namespace ViewModel
    {
        public class EditStudentRecordViewModel
        {
            private Model.Student _student;
            private IEnumerable<Model.Class> _studentClasses;
            /* Bind your View to these fields: */
            public string FullName
            {
                return _student.LastName + ", " + _student.FirstName;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public IEnumerable<Model.Class> PassingClasses
            {
                get
                {
                    return _studentClasses.Where( c => c.Score >= 78 );
                }
            }
            public IEnumerable<Model.Class> FailingClasses
            {
                get
                {
                    return _studentClasses.Where( c => c.Score < 78 );
                }
            }
            public void Save()
            {
                List<string> l_validationErrors = new List<string>();
                if ( string.IsNullOrEmpty( this.FirstName ) )
                    l_validationErrors.Add( "First Name must not be empty." );
                if ( string.IsNullOrEmpty( this.LastName ) )
                    l_validationErrors.Add( "Last Name must not be empty." );
                if ( l_validationErrors.Any() )
                    return;
                _student.FirstName = this.FirstName;
                _student.LastName = this.LastName;
                Model.Utilities.SaveStudent( _student );
            }
        }
    }
