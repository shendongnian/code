    // I've made Condition an abstract class to super any kind of condition.
    // Just derive this class with the condition you want (And, Or, Equal, <=, IsNumber, ...)
    public abstract class Condition
    {
        // A condition is defined by this method. Because a condition is basically: "Does the specified value satisfy the condition?"
        public abstract bool Satisfy(string valueToTest);  
    }
    // This is the first example of condition.
    // I wanted to make the condition immutable (readonly) not to be able to change them.
    // So, all parameters of the condition are set during the construction.
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
            return value == valueToTest;  // Equals condition...
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
            return valueToTest.Contains(valueToTest);  // Contains condition
        }
    }
    // The dictionary is used to list the conditions applied to each element.
    Dictionary<string, Condition> conditions = new Dictionary<string, Condition> { { "name", new EqualCondition("John") } };  
    XDocument document = XDocument.Load("test.xml");
    var booms = from boomElement in document.Descendants("boom")
                // The next line check where all conditions are satisfied for the corresponding elements
                where conditions.All(condition => condition.Value.Satisfy((string)boomElement.Element(condition.Key)))
                let boomChildren = (from boomElementChild in boomElement.Elements()
                                    select String.Format("{0}: {1}",
                                                            boomElementChild.Name.LocalName,
                                                            boomElementChild.Value))
                select String.Join(Environment.NewLine, boomChildren);
    var result = String.Join(Environment.NewLine + Environment.NewLine, booms);
