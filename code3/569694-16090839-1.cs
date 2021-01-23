		static string APPNODE = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".Properties.Settings";
		static DateTime now = DateTime.Now;
		Utilities.UpdateConfig(APPNODE, "lastQueryTime", now.ToString());
		static public void UpdateConfig(string section, string key, string value)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			ClientSettingsSection applicationSettingsSection = (ClientSettingsSection)config.SectionGroups["applicationSettings"].Sections[section];
			SettingElement element = applicationSettingsSection.Settings.Get(key);
			if (null != element)
			{
				applicationSettingsSection.Settings.Remove(element);
				element.Value.ValueXml.InnerXml = value;
				applicationSettingsSection.Settings.Add(element);
			}
			else
			{
				element = new SettingElement(key, SettingsSerializeAs.String);
				element.Value = new SettingValueElement();
				System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
				element.Value.ValueXml = doc.CreateElement("value");
				element.Value.ValueXml.InnerXml = value;
				applicationSettingsSection.Settings.Add(element);
			}
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("applicationSettings");            
		}
