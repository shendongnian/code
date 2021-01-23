        private void test()
        {
            Indices indices = new Indices();
            indices.ColorIndex = 20;
            var validationContext = new ValidationContext(indices);
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var tryValidateObject = Validator.TryValidateObject(indices, validationContext, validationResults,true);
        }
    public class Indices
    {
        [Range(1, 10)]
        public int ColorIndex { get; set; }
        public string ColorPrefix { get; set; }
        public int GradientIndex { get; set; }
        public string GradientPrefix { get; set; }
    }
