    public class EvaluationObject
    {
        public IEnumerable<SelectListItem> EvaluationList
        {
            get
            {
                return Enumerable.Range(1, 4)
                                 .Select(x => new SelectListItem
                                     {
                                         Selected = x == MaxValue,
                                         Text = NumberToWord(x),
                                         Value = x
                                     });
            }
        }
        public int MaxValue { get; set; }
        public int EvaluationNumber { get; set; }
    }
