        /// <summary>
        /// Corrects the roaming settings file if needed because sometimes the node "configSections" is missing in the settings file. 
        /// Correct this by taking this node out of the default config file.
        /// </summary>
        private static void CorrectRoamingSettingsFileIfNeeded()
        {
            const string NODE_NAME_CONFIGURATION = "configuration";
            const string NODE_NAME_CONFIGSECTIONS = "configSections";
            const string NODE_NAME_USERSETTINGS = "userSettings";
            const string ADDIN_DLL_FILENAME = "TNPExcelAddIn2.dll";
            //Exit if no romaing config (file) to correct...
            var configRoaming = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            if (configRoaming == null) return;
            if (!configRoaming.HasFile) return;
            //Check for the <sectionGroup> with name="userSettings"
            //Note: Used ugly iteration because "configRoaming.GetSectionGroup(sectionGroupName)" throws ArgumentException.
            ConfigurationSectionGroup sectionGroupUserSettings = null;
            foreach (ConfigurationSectionGroup sectionGroup in configRoaming.SectionGroups)
            {
                if (sectionGroup.Name.Equals(NODE_NAME_USERSETTINGS))
                {
                    sectionGroupUserSettings = sectionGroup;
                    break;
                }
            }
            //Exit if the needed section group is found...
            if (sectionGroupUserSettings != null && sectionGroupUserSettings.IsDeclared) return;
            //Do correction actions...
            var xDoc = XDocument.Load(configRoaming.FilePath);
            var userSettingsNode = xDoc.Element(NODE_NAME_CONFIGURATION).Element(NODE_NAME_USERSETTINGS);
            var addInDllConfigFullFilename = AppDomain.CurrentDomain.BaseDirectory + ADDIN_DLL_FILENAME;
            var configDefault = ConfigurationManager.OpenExeConfiguration(addInDllConfigFullFilename);
            var xDocDefault = XDocument.Load(configDefault.FilePath);
            var configSectionsNode = xDocDefault.Element(NODE_NAME_CONFIGURATION).Element(NODE_NAME_CONFIGSECTIONS);
            userSettingsNode.AddBeforeSelf(configSectionsNode);
            xDoc.Save(configRoaming.FilePath);
        }
