    // In a manually generated file in the same project
    public partial class emUser
    {
        #region Properties
        public string Username
        {
            get { return Email; }
        }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        #endregion
    }
    
    // In the automatically generated file
    public partial class emUser : EntityObject
    {
        [code ...]
    }
