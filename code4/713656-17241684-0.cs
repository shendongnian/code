	using System;
	using System.Linq;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	namespace WebBrowser
	{
	    public partial class Form1 : Form
	    {
		
		public Form1()
		{
		    checkMSHTML(0);
		    InitializeComponent();
		    webBrowser1.ScriptErrorsSuppressed = false;
		}
		private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
		    switch (e.Button.ImageIndex)
		    {
		        case 0:
		            webBrowser1.Url = new Uri( "http://192.168.128.5/www");
		            break;
		        case 1:
		            this.Close();
		            break;
		    }
		}
		/// <summary>
		/// check and change MSHTML rendering engine
		/// </summary>
		/// <param name="iVal">0 = use new IE6 engine, enable JavaScript
		/// 1 = use old PIE engine</param>
		/// <returns></returns>
		bool checkMSHTML(int iVal)
		{
		    bool bRet = false;
		    Microsoft.Win32.RegistryKey rKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Security\Internet Explorer",true);
		    if (rKey != null)
		    {
		        int iMSHTML = (int) rKey.GetValue("MSHTML");
		        if (iMSHTML != iVal)
		        {
		            rKey.SetValue("MSHTML", iVal, Microsoft.Win32.RegistryValueKind.DWord);
		            rKey.Flush();
		            rKey.Close();
		            bRet = true;
		        }
		        else
		        {
		            rKey.Close();
		            bRet = true;
		        }
		    }
		    return bRet;
		}
	    }
	}
