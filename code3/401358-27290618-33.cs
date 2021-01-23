    public class StringArg : ConstructorArgs
    {
        public string _gradeTypeStringFromXmlFile { get; set; }
        public StringArg (string gradeTypeStringFromXmlFile)
        {
            this._gradeTypeStringFromXmlFile = gradeTypeStringFromXmlFile ;
        }
    }
    public class EnumArg : ConstructorArgs
    {
        public Enum.GradeType _gradeType { get; set; }
        public EnumArg (Enum.GradeType gradeType)
        {
            this._gradeType = gradeType ;
        }
    }
