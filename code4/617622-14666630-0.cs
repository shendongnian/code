    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using EnvDTE;
    using Microsoft.VisualStudio.TemplateWizard;
    
    namespace WarrenG.StartAction {
        public class Wizard : IWizard {
            private readonly Dictionary<string, object> data = new Dictionary<string, object>();
    
    
            public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary,
                                   WizardRunKind runKind, object[] customParams) {
                if (replacementsDictionary.ContainsKey("$wizarddata$")) {
                    string xml = replacementsDictionary["$wizarddata$"];
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml);
                    foreach (XmlNode node in doc.ChildNodes) {
                        data.Add(node.Name, node.InnerText);
                    }
                }
            }
    
            public bool ShouldAddProjectItem(string filePath) {
                return true;
            }
    
            public void RunFinished() {
            }
    
            public void BeforeOpeningFile(ProjectItem projectItem) {
            }
    
            public void ProjectItemFinishedGenerating(ProjectItem projectItem) {
            }
    
            public void ProjectFinishedGenerating(Project project) {
                if (data.ContainsKey("WebApplication.DebugStartAction")) {
                    project.Properties.Item("WebApplication.DebugStartAction").Value =
                        data["WebApplication.DebugStartAction"];
                } else {
                    project.Properties.Item("WebApplication.DebugStartAction").Value = 1;
                }
            }
        }
    }
