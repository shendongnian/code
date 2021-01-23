    public static void RemoveFirewallRules(string RuleName)
    {
        try
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;               
            // List of rules
            // List<INetFwRule> RuleList = new List<INetFwRule>();
            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                // Add a rule to list
                // RuleList.Add(rule);
                // Console.WriteLine(rule.Name);
                if (rule.Name.IndexOf(RuleName) != -1)
                {
                    // Remove a rule
                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));                     
                    firewallPolicy.Rules.Remove(rule.Name);
                    Console.WriteLine(rule.Name + " has been deleted from the Firewall Policy");
                }
            }
        }
        catch (Exception r)
        {
            Console.WriteLine("Error deleting a Firewall rule");
        }
    }
