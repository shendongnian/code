    public sealed class SiteSupport {
        /// <summary>
        /// Retrieve specific section value from the web.config
        /// </summary>
        /// <param name="configSection">Main Web.config section</param>
        /// <param name="subSection">Child Section{One layer down}</param>
        /// <param name="innersection">Keyed on Section Name</param>
        /// <param name="propertyName">Element property name</param>
        /// <returns></returns>
        /// <example>string setting = MercuryCRM.Common.Utilities.SiteSupport.RetrieveApplicationSetting("applicationSettings", "Mercury.UPSWorldship.Properties.Settings", "ShipWS_ShipWebReference_ShipService", "value")</example>
        public static string RetrieveApplicationSetting(string configSection, string subSection, string innersection, string propertyName) {
            string result = string.Empty;
            HttpWorkerRequest fakeWorkerRequest = null;
            try {
                using (TextWriter textWriter = new StringWriter()) {
                    fakeWorkerRequest = new SimpleWorkerRequest("default.aspx", "", textWriter);
                    var fakeHTTPContext = new HttpContext(fakeWorkerRequest);
                    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap() { ExeConfigFilename = fakeHTTPContext.Server.MapPath(@"~/Web.config") }, ConfigurationUserLevel.None);
                    ConfigurationSectionGroup group = config.SectionGroups[configSection];
                    if (group != null) {
                        ClientSettingsSection clientSection = group.Sections[subSection] as ClientSettingsSection;
                        if (clientSection != null) {
                            SettingElement settingElement = clientSection.Settings.Get(innersection);
                            if (settingElement != null) {
                                result = (((SettingValueElement)(settingElement.ElementInformation.Properties[propertyName].Value)).ValueXml).InnerText;
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                fakeWorkerRequest.CloseConnection();
            }
            return result;
        }
    }
