        public static void RemoveFirewallRules(string RuleName = "BreakermindCom")
    {
        try
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;               
            // Lista rules
            // List<INetFwRule> RuleList = new List<INetFwRule>();
            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                // Add rule to list
                // RuleList.Add(rule);
                // Console.WriteLine(rule.Name);
                if (rule.Name.IndexOf(RuleName) != -1)
                {
                    // Now remove rule
                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));                     
                    firewallPolicy.Rules.Remove(rule.Name);
                    Console.WriteLine(rule.Name + " has been deleted from Firewall Policy");
                }
            }
        }
        catch (Exception r)
        {
            Console.WriteLine("Error delete rule from firewall");
        }}
