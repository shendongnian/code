    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SAPFEWSELib;
    using SapROTWr;
    
    namespace FIT.SapHelper
    {
        public static class stcSapHelper
        {
            public static void testConnection()
            {
                SapROTWr.CSapROTWrapper sapROTWrapper = new SapROTWr.CSapROTWrapper();
                object SapGuilRot = sapROTWrapper.GetROTEntry("SAPGUI");
                object engine = SapGuilRot.GetType().InvokeMember("GetScriptingEngine", System.Reflection.BindingFlags.InvokeMethod, null, SapGuilRot, null);
                GuiConnection connection = (engine as GuiApplication).OpenConnection("BOX DESCRIPTION");
                GuiSession session = connection.Children.ElementAt(0) as GuiSession;
            }
        }
    }
