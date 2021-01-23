    public class ColViewModel
    {
        public string RowNumber { get; set; }
        public string ColumnNumber { get; set; }
        public string QuestionText { get; set; }
        public string FieldValue { get; set; }
    }
    public class RowViewModel
    {
        public List<ColViewModel> Columns { get; set; }
    }
