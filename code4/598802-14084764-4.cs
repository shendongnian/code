    public class AgentXmlRepository : IAgentRepository
    {
        private string _xmlAgentsFile;
        public AgentXmlRepository(string xmlAgentsFile)
        {
            _xmlAgentsFile = xmlAgentsFile;
        }
        public IList<Agent> LoadAgents()
        {
            XDocument AgentBase = XDocument.Load(_xmlAgentsFile);
            var agents = new List<Agent>();
            foreach (XElement el in AgentBase.Descendants("AGENT")) {
                var agent = new Agent {
                    Index = el.Element("AGENT_INDEX").Value,
                    PorterIndex = el.Element("AGENT_PORTER_INDEX").Value,
                    Name = el.Element("AGENT_NAME").Value,
                    Surname = el.Element("AGENT_SURNAME").Value,
                    Mobile = el.Element("AGENT_MOBILE_NUMBER").Value
                };
                agents.Add(agent);
            }
            return agents;
        }
        public void Save(IEnumerable<Agent> agents)
        {
            var xDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("COREBASE",
                    agents.Select(a =>
                        new XElement("AGENT",
                            new XElement("AGENT_INDEX", a.Index),
                            new XElement("AGENT_PORTER_INDEX", a.PorterIndex),
                            new XElement("AGENT_NAME", a.Name),
                            new XElement("AGENT_SURNAME", a.Surname),
                            new XElement("AGENT_MOBILE_NUMBER", a.Mobile)
                        )
                    )
                )
            );
            xDocument.Save(_xmlAgentsFile);
        }
    }
