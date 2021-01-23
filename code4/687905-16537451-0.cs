    [When(@"in element '(.*)' I enter '(.*)'")]
    public void WhenIEnterInElement(string element, DateTime value)
    {
        Enter(value, element.ToString());
    }
    [StepArgumentTransformation(@"today plus (\d+) days")]
    public DateTime ConvertDate(int days)
    {
        return DateTime.Today.AddDays(days);
    }
