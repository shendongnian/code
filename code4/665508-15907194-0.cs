        public class AgentState
        {
            public string agentName { get; set; }
            public string extension { get; set; }
            public string currentlyIn { get; set; }
        }
        static void Main(string[] args)
        {
            var s = @"<AgentState>
                        <agentName>jbloggs</agentName>
                        <extension>12345</extension>
                        <currentlyIn>TestStatus</currentlyIn>
                    </AgentState>";
            XmlSerializer serializer = new XmlSerializer(typeof(AgentState));
            var ms = new MemoryStream(Encoding.ASCII.GetBytes(s));
            var obj = serializer.Deserialize(ms);
        }
