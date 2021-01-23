    public class Student: EditableObject<WPF.MVVMBase.Student.StudentData>
        {
            #region Struct
    
            public struct StudentData
            {
                public string firstName;
                public string lastName;
            }
    
            #endregion
    
            #region Public Properties
    
            [ObservableProperty]
            public string FirstName
            {
                get
                {
                    return _editData.firstName;
                }
                set
                {
                    _editData.firstName = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
    
            [ObservableProperty]
            public string LastName
            {
                get
                {
                    return _editData.lastName;
                }
                set
                {
                    _editData.lastName = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
    
            #endregion
    
            #region Methods
    
            protected override bool SaveObject()
            {
                //Save Student Changes to Database
    
                return true;
            }
    
            protected override bool RemoveObject()
            {
                //Remove Student from Database
    
                return true;
            }
    
            #endregion
        }
