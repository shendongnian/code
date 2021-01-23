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
        
                //int handle = FindWindow(null, "Facebook - Windows Internet Explorer");
                
                //Give focus to the screen with the wanted name
                public static void DonnerFocus(string pNomFenetre)
        
    
        {
                //Get the handle of the app you want to send keys to
                int handle = FindWindow(null, pNomFenetre);
    
                //Set it to the foreground
                SetForegroundWindow(handle);
            }
    
            //write the string
            public static void Ecrire(string pPhrase)
            {
                //Send the keys on over
                SendKeys.SendWait(pPhrase);
            }
    
            //write a string and press enter
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
