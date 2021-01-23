    public class GradeTypeArgs1 : ConstructorArgs
    {
        public string _gradeTypeStringFromXmlFile { get; set; }
        public GradeTypeArgs1(string gradeTypeStringFromXmlFile)
        {
            this._gradeTypeStringFromXmlFile = gradeTypeStringFromXmlFile ;
        }
    }
    public class GradeTypeArgs2 : ConstructorArgs
    {
        public Enum.GradeType _gradeType { get; set; }
        public GradeTypeArgs2 (Enum.GradeType gradeType)
        {
            this._gradeType = gradeType ;
        }
    }
