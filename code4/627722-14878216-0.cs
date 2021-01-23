            using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    namespace Abyte0
        {
            public partial class ClavierVirtuel
            {
                [DllImport("user32.dll", EntryPoint = "FindWindow")]
                private static extern int FindWindow(string _ClassName, string _WindowName);
        
                [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
                private static extern int SetForegroundWindow(int hwnd);
        
                //int handle = FindWindow(null, "[ Mibbit ] - Windows Internet Explorer");
                //"Facebook - Windows Internet Explorer"
        
                public static void DonnerFocus(string pNomFenetre)
        
    
        {
                //Get the handle of the app you want to send keys to
                int handle = FindWindow(null, pNomFenetre);
    
                //Set it to the foreground
                SetForegroundWindow(handle);
            }
    
            public static void Ecrire(string pPhrase)
            {
                //Send the keys on over
                SendKeys.SendWait(pPhrase);
            }
    
            public static void ecrire_Enter(string pPhrase)
            {
                foreach (char lettre in pPhrase)
                {
                    SendKeys.SendWait(lettre.ToString());
                }
                System.Threading.Thread.Sleep(10);
                SendKeys.SendWait("{ENTER}");
            }
        }
    }
