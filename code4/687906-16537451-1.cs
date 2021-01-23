    public class WrappedString
    {
        public string Value;
        public WrappedString(string value):Value(value) {}
    }
    [When(@"in element '(.*)' I enter '(.*)'")]
    public void WhenIEnterInElement(string element, WrappedString value)
    {
        Enter(value, element.Value);
    }
    [StepArgumentTransformation(@"today plus (\d+) days")]
    public WrappedString ConvertDate(int days)
    {
        return new WrappedString(DateTime.Today.AddDays(days).ToString());
    }
