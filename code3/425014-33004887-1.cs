    private void disableUAC()
        {
            RegistryKey regKey = null;
            try
            {
                regKey = Registry.LocalMachine.OpenSubKey(ControlServiceResources.UAC_REG_KEY, true);
            }
            catch (Exception e)
            {
                //Error accessing registry
            }
            try
            {
                regKey.SetValue("ConsentPromptBehaviorAdmin", 0);
            }
            catch (Exception e)
            {
                //Error during Promt disabling
            }
        }
