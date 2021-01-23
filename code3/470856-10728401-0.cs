    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Automation;
    using System.Diagnostics;
    using System.Threading;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var pInfo = new ProcessStartInfo("notepad");
                
                var p = Process.Start(pInfo);
    
                p.WaitForInputIdle();
    
                AutomationElement installerEditorForm = AutomationElement.FromHandle(p.MainWindowHandle);
                
                // menus
                AutomationElementCollection menuBars = installerEditorForm.FindAll(TreeScope.Children, new PropertyCondition(
                    AutomationElement.ControlTypeProperty, ControlType.MenuBar));
    
                var mainMenuItem = menuBars[0];
                
                AutomationElementCollection menus = mainMenuItem.FindAll(TreeScope.Children, new PropertyCondition(
                    AutomationElement.ControlTypeProperty, ControlType.MenuItem));
    
                var fileMenuItem = menus[0];
                
                ExpandCollapsePattern fileMenuItemOpenPattern = (ExpandCollapsePattern)fileMenuItem.GetCurrentPattern(
                    ExpandCollapsePattern.Pattern);
                
                fileMenuItemOpenPattern.Expand();
                
                AutomationElement fileMenuItemNew = fileMenuItem.FindFirst(TreeScope.Children,
                    new AndCondition(
                        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem),
                        new PropertyCondition(AutomationElement.NameProperty, "New")));
    
                Console.Read();
            }
        }
    }
