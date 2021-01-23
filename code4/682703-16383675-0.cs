    class ServerFunction {
        public string LocalHost;
        public string User;
        public string Pass;
        //Copy Constructor
        public ServerFunction(ServerFunction obj)
        {
            LocalHost = obj.LocalHost;
            User = obj.User;
            Pass = obj.Pass;
        }
        //Constructor
        public MemberFunction()
        {
            LocalHost = null;
            User = null;
            Pass = null;
        }
    }
    
    //Object of the Class
    ServerFunction func = new ServerFunction(); 
   
    static void Main(string[] args)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load("server.xml");
        XmlElement root = xmlDoc.DocumentElement;
        foreach (XmlNode node in root.ChildNodes)
        {
                    func.LocalHost = node.Attributes["address"].Value;
                    func.User = node.Attributes["username"].Value;
                    func.Pass = node.Attributes["password"].Value;
                    
        }
    
    }
