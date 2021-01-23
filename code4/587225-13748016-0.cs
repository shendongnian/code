    public class Program
    {
        private static void Main(string[] args)
        {
            var allAnalysisSets = new AnalysisSet[] {
                new AnalysisSet(){
                    ProviderName = "productname1",
                    Rules = new Rule[]{
                    new Rule(){ Title="rule1" }
                } },
                new AnalysisSet(){
                    ProviderName = "productname2",
                    Rules = new Rule[]{
                    new Rule(){ Title="rule1" },
                    new Rule(){ Title="rule2" }
                } }
            };
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            using (var xw = XmlWriter.Create(sw, new XmlWriterSettings() { Indent = true }))
            {
                new XElement("AnalaysisSets"
                    , allAnalysisSets
                        .Select(set => new XElement("AnalysisSet"
                                , new XAttribute("ProviderName", set.ProviderName)
                                , new XElement("Results"
                                    , set.Rules.Select(rule => rule.GetRuleState())
                                )
                            )
                        )
                ).WriteTo(xw);
            }
            Console.Write(sb.ToString());
            Console.ReadLine();
        }
    }
    public class AnalysisSet
    {
        public IEnumerable<Rule> Rules { get; set; }
        public string ProviderName { get; set; }
    }
    public class Rule
    {
        public string Title { get; set; }
        public XStreamingElement GetRuleState()
        {
            return new XStreamingElement("RuleResult",
                new XElement("Title", Title));
        }
    }
