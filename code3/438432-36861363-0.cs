    public class YourClass
    {
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        public string paragraph { get; set; }
    }
    @Html.TextAreaFor(m => m.paragraph, new { @class = "form-control", @rows = 5 })
