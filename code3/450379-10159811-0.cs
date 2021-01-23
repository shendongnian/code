    using System;
    using System.Diagnostics;
    
    public sealed class WhereWrapper
    {
    	private static string _exePath = null;
    	
    	public static int Main(string[] args) {
    
    		int exitCode;
    		string exeToFind = args.Length > 0 ? args[0] : "WHERE";
    
    		Process whereCommand = new Process();
    
    		whereCommand.OutputDataReceived += Where_OutputDataReceived;
    		
    		whereCommand.StartInfo.FileName = "WHERE";
    		whereCommand.StartInfo.Arguments = exeToFind;
    		whereCommand.StartInfo.UseShellExecute = false;
    		whereCommand.StartInfo.CreateNoWindow = true;
    		whereCommand.StartInfo.RedirectStandardOutput = true;
    		whereCommand.StartInfo.RedirectStandardError = true;
    
    		try  {
    			whereCommand.Start();
    			whereCommand.BeginOutputReadLine();
    			whereCommand.BeginErrorReadLine();
    			whereCommand.WaitForExit();
    			exitCode = whereCommand.ExitCode;
    			
    		} catch (Exception ex) {
    			exitCode = 1;
    			Console.WriteLine(ex.Message);
    			
    		} finally {
    			whereCommand.Close();
    		}
    
    		Console.WriteLine("The path to {0} is {1}", exeToFind, _exePath ?? "{not found}");
    		
    		return exitCode;
    	}
    
    	private static void Where_OutputDataReceived(object sender, DataReceivedEventArgs args) {
    
    		if (args.Data != null) {
    			_exePath = args.Data;
    		}
    	}
    }
