    using System;
    using System.Collections;
    using NetFwTypeLib;
    
    namespace FirewallPorts
    {
        class FwPorts
        {
            static void Main(string[] args)
            {
                Type fwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2", true);
                INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(fwPolicy2Type);
                int currentProfs = fwPolicy.CurrentProfileTypes;
                NET_FW_PROFILE_TYPE2_ foo = (NET_FW_PROFILE_TYPE2_)currentProfs;
                if (foo.HasFlag(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE))
                    Console.WriteLine("PrivateNet");
                if (!foo.HasFlag(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC))
                    Console.WriteLine("NOT PUBLIC");
                bool fpsEnabled = fwPolicy.IsRuleGroupCurrentlyEnabled["File and Printer Sharing"];
                bool FwEnabled = fwPolicy.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC] || fwPolicy.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE];
                Console.WriteLine($"Windows Firewall enabled is {FwEnabled}");
                INetFwRules rules = fwPolicy.Rules;
                foreach (INetFwRule item in rules)
                {
                    if (item.Enabled && item.Name.Contains("Sharing"))
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine($"LocalPorts: {item.LocalPorts}, {(NET_FW_PROFILE_TYPE2_)item.Profiles}");
                        Console.WriteLine(item.Description + "\r\n");
                    }
                }
            }
        }
    }
