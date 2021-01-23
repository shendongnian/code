    public static void testConnection()
            {
                SapROTWr.CSapROTWrapper sapROTWrapper = new SapROTWr.CSapROTWrapper();
                object SapGuilRot = sapROTWrapper.GetROTEntry("SAPGUI");
                object engine = SapGuilRot.GetType().InvokeMember("GetSCriptingEngine", System.Reflection.BindingFlags.InvokeMethod,
                    null, SapGuilRot, null);
                SAPconnection.sapGuiApp = engine as GuiApplication;
                GuiConnection connection = sapGuiApp.Connections.ElementAt(0) as GuiConnection;
                GuiSession session = connection.Children.ElementAt(0) as GuiSession;
                MessageBox.Show(session.Info.User + " !!||!! " + session.Info.Transaction);
                
                
            }
