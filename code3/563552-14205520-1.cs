    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using SAPFEWSELib;
    
    namespace SAPGuiAutomated
    {
    //created a class for the SAP app, connection, and session objects as well as for common methods. 
        public class SAPActive
        {
            public static GuiApplication SapGuiApp { get; set; }
            public static GuiConnection SapConnection { get; set; }
            public static GuiSession SapSession { get; set; }
    
            public static void openSap(string env)
            {
                SAPActive.SapGuiApp = new GuiApplication();
    
                string connectString = null;
                if (env.ToUpper().Equals("DEFAULT"))
                {
                    connectString = "1.0 Test ERP (DEFAULT)";
                }
                else
                {
                    connectString = env;
                }
                SAPActive.SapConnection = SAPActive.SapGuiApp.OpenConnection(connectString, Sync: true); //creates connection
                SAPActive.SapSession = (GuiSession)SAPActive.SapConnection.Sessions.Item(0); //creates the Gui session off the connection you made
            }
    		
    		public void login(string myclient, string mylogin, string mypass, string mylang)
    		{
    			GuiTextField client  = (GuiTextField)SAPActive.SapSession.ActiveWindow.FindByName("RSYST-MANDT", "GuiTextField");
                GuiTextField login  = (GuiTextField)SAPActive.SapSession.ActiveWindow.FindByName("RSYST-BNAME", "GuiTextField");
                GuiTextField pass  = (GuiTextField)SAPActive.SapSession.ActiveWindow.FindByName("RSYST-BCODE", "GuiPasswordField");
                GuiTextField language  = (GuiTextField)SAPActive.SapSession.ActiveWindow.FindByName("RSYST-LANGU", "GuiTextField");
    			
    			client.SetFocus();
    			client.text = myclient;
    			login.SetFocus();
    			login.Text = mylogin;
    			pass.SetFocus();
    			pass.Text = mypass;
    			language.SetFocus();
    			language.Text = mylang; 
    			
    			//Press the green checkmark button which is about the same as the enter key 
    			GuiButton btn = (GuiButton)SapSession.FindById("/app/con[0]/ses[0]/wnd[0]/tbar[0]/btn[0]");
    			btn.SetFocus(); 
    			btn.Press();
    			
    		}
    	}
    	//--------------------------//
    	//main method somewhere else 
    	public static void Main(string[] args)
    	{
    		SAPActive.openSAP("my connection string");
    		SAPActive.login("10", "jdoe", "password", "EN");
    		SAPActive.SapSession.StartTransaction("VA03");
    	}
    	
