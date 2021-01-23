    public abstract class Condition
    {
        public abstract bool Satisfy(string valueToTest);
    }
    public sealed class EqualCondition : Condition
    {
        private readonly string value;
        public string Value { get { return value; } }
        public EqualCondition(string value)
        {
            this.value = value;
        }
        public override bool Satisfy(string valueToTest)
        {
            return value == valueToTest;
        }
    }
    public sealed class ContainCondition : Condition
    {
        private readonly string value;
        public string Value { get { return value; } }
        public ContainCondition(string value)
        {
            this.value = value;
        }
        public override bool Satisfy(string valueToTest)
        {
            return valueToTest.Contains(valueToTest);
        }
    }
    Dictionary<string, Condition> conditions = new Dictionary<string, Condition> { { "name", new EqualCondition("John") } };
    XDocument document = XDocument.Load("test.xml");
    var booms = from boomElement in document.Descendants("boom")
                where conditions.All(condition => condition.Value.Satisfy((string)boomElement.Element(condition.Key)))
                let boomChildren = (from boomElementChild in boomElement.Elements()
                                    select String.Format("{0}: {1}",
                                                            boomElementChild.Name.LocalName,
                                                            boomElementChild.Value))
                select String.Join(Environment.NewLine, boomChildren);
    var result = String.Join(Environment.NewLine + Environment.NewLine, booms);
