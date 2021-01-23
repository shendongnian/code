        private string agentId;
        public string AgentId
        {
            get { return agentId; }
            set { agentId = this.scrubAgentId(value); } 
        }
    
        private string scrubAgentId(string value)
        {
            if(value == null)
                return value;
            char[] arr = value.ToCharArray();
            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c))));
            return new string(arr);
        }
    
