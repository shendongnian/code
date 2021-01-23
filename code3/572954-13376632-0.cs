    using System;
    using WindowsInstaller;
    
    namespace DataImporter
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    
    			string startMenuDir = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
    			string shortcutold = Path.Combine(startMenuDir, @"Ohal\TV AMP (Windows XP Mode).lnk");
    			if (File.Exists(shortcutold))
    			File.Delete(shortcutold);
    
    
    			string startMenuDir = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
    			string shortcut = Path.Combine(startMenuDir, @"Ohal\TV AMP.lnk");
    			if (File.Exists(shortcut))
    			{
    				Console.WriteLine("Already installed...");
    			}
    			else
    			{
    			Type type = Type.GetTypeFromProgID("WindowsInstaller.Installer");
    						Installer installer = (Installer)Activator.CreateInstance(type);
    						installer.InstallProduct(@"Y:\LibSetup\TVAMP313\TVAmp v3.13.msi");
    			}
    		}
    	}
    }
