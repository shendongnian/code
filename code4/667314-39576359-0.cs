    public class DataTableOrder
    {
        public int Column { get; set; }
        [FromForm(Name = "Dir")]
        public string Direction { get; set; }
    }
