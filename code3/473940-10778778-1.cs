    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    public class Form1
    {
    	[DllImport("user32.dll", EntryPoint = "FindWindowA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    
    	private static extern Int32 FindWindow(string lpClassName, string lpWindowName);
    	[DllImport("user32.dll", EntryPoint = "FindWindowExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    
    	private static extern Int32 FindWindowEx(Int32 hWnd1, Int32 hWnd2, string lpsz1, string lpsz2);
    	[DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    
    	private static extern Int32 EnableWindow(Int32 hwnd, Int32 fEnable);
    
    
    	private void Button1_Click(System.Object sender, System.EventArgs e)
    	{
    		Timer1.Enabled = true;
    
    		FolderBrowserDialog fld = new FolderBrowserDialog();
    
    		fld.ShowDialog(this);
    
    	}
    
    
    	private void Timer1_Tick(System.Object sender, System.EventArgs e)
    	{
    		Int32 hwndMainWindow = default(Int32);
    
    		hwndMainWindow = FindWindow("#32770".Trim(), Constants.vbNullString);
    		// '#32770 (Dialog)#32770 (Dialog)
    
    
    		if (hwndMainWindow) {
    			Int32 hwndBtn = default(Int32);
    
    			hwndBtn = FindWindowEx(hwndMainWindow, IntPtr.Zero, "Button", "OK");
    
    
    			if (hwndBtn) {
    				EnableWindow(hwndBtn, 0);
    
    			}
    
    		}
    
    		Timer1.Enabled = false;
    
    	}
    
    }
