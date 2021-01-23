    using IronPython.Hosting;//for DLHE
    using Microsoft.Scripting.Hosting;//provides scripting abilities comparable to batch files
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    class Hi
    {
	private static void Main(string []args)
	{
	Process process = new Process(); //to make a process call
	ScriptEngine engine = Python.CreateEngine(); //For Engine to initiate the script
	engine.ExecuteFile(@"C:\Users\daulmalik\AppData\Local\Programs\Python\Python37\p1.py");//Path of my .py file that I would like to see running in console after running my .cs file from VS.//process.StandardInput.Flush();
	process.StandardInput.Close();//to close
	process.WaitForExit();//to hold the process i.e. cmd screen as output
    }
    } 
