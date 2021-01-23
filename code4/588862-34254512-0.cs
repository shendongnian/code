    public static bool isFirewallEnabled() {
            try {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\StandardProfile")) {
                    if (key == null) {
                        return false;
                    } else { 
                        Object o = key.GetValue("EnableFirewall");
                        if (o == null) {
                            return false;
                        } else {
                            int firewall = (int)o;
                            if (firewall == 1) {
                                return true;
                            } else {
                                return false;
                            }
                        }
                    }
                }
            } catch {
                return false;
            }
        }
