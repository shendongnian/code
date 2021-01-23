    [System.Xml.Serialization.XmlRootAttribute("AgentState")]
    public class AgentState
    {
        public string agentName {get; set;}
    	public int extension {get; set;}
    	public string currentlyIn {get; set;}
    }
    
    public void RunSerializer()
    {
        System.Xml.Serialization.XmlSerializer agent_serializer =
           new System.Xml.Serialization.XmlSerializer(typeof(AgentState));
        string agent_state_text = File.ReadAllText(@"C:\Temp\AgentState.xml");
    	Console.WriteLine(agent_state_text + Environment.NewLine);
    	string xml_agent_state = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" + agent_state_text;
    	Console.WriteLine(xml_agent_state + Environment.NewLine);
    	
    	AgentState agent_state = new AgentState();
    	using(StringReader tx_reader = new StringReader(xml_agent_state))
    	{
            if (tx_reader != null)
            {
                agent_state = (AgentState)agent_serializer.Deserialize(tx_reader);
            }
    	}
    	Console.WriteLine(agent_state.agentName);
    	Console.WriteLine(agent_state.extension);
    	Console.WriteLine(agent_state.currentlyIn);
    }
