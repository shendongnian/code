    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using NetFwTypeLib;
    namespace WinFirewall
    {
        public class FWCtrl
        {
            const string guidFWPolicy2 = "{E2B3C97F-6AE1-41AC-817A-F6F92166D7DD}";
            const string guidRWRule = "{2C5BC43E-3369-4C33-AB0C-BE9469677AF4}";
            static void Main(string[] args)
            {
                FWCtrl ctrl = new FWCtrl();
                ctrl.Setup();
            }
            public void Setup()
            {
                Type typeFWPolicy2 = Type.GetTypeFromCLSID(new Guid(guidFWPolicy2));
                Type typeFWRule = Type.GetTypeFromCLSID(new Guid(guidRWRule));
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(typeFWPolicy2);
                INetFwRule newRule = (INetFwRule)Activator.CreateInstance(typeFWRule);
                newRule.Name = "InBound_Rule";
                newRule.Description = "Block inbound traffic from 192.168.0.2 over TCP port 4000";
                newRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                newRule.LocalPorts = "4000";
                newRule.RemoteAddress = "192.168.0.2";
                newRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                newRule.Enabled = true;
                newRule.Grouping = "@firewallapi.dll,-23255";
                newRule.Profiles = fwPolicy2.CurrentProfileTypes;
                newRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                fwPolicy2.Rules.Add(newRule);
            }
        }
    }
