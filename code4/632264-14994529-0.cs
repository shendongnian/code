    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    // Add a reference to "C:\Windows\System32\shdocvw.dll"
    
    namespace BrowserAutomation
    {
        class Program
        {   
            static void Main(string[] args)
            {
                var ie = new SHDocVw.InternetExplorer();
                // Ensure that ie.Quit() is called at the end via the destructor
                var raii = new IE_RAII(ie);
                // Just so you can see what's going on for now
                ie.Visible = true;
                ie.Navigate2("http://www.wellsfargo.com");
                var document = GetDocument(ie);
                var userid = document.getElementById("userid");
                userid.Value = "billy.everyteen";
                var password = document.getElementById("password");
                password.Value = "monroebot";
                var form = document.Forms("signon");
                form.Submit();
                // Hang out for a while...
                System.Threading.Thread.Sleep(10000);
            }
            // Poor man's check and wait until DOM is ready
            static dynamic GetDocument(SHDocVw.InternetExplorer ie)
            {
                while (true)
                {
                    try
                    {
                        return ie.Document;
                    }
                    catch (System.Runtime.InteropServices.COMException e)
                    {
                        if (e.Message != "Error HRESULT E_FAIL has been returned " +
                                         "from a call to a COM component.")
                        {
                            throw e;
                        }
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        class IE_RAII
        {
            public IE_RAII(SHDocVw.InternetExplorer ie)
            {
                _ie = ie;
            }
            ~IE_RAII()
            {
                _ie.Quit();
            }
            private SHDocVw.InternetExplorer _ie;
        }
    }
