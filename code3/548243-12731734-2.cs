using using System.Configuration;
// Get the AppSettings section.        
// This function uses the AppSettings property
// to read the appSettings configuration 
// section.
public static void ReadAppSettings()
{
  try
  {
    // Get the AppSettings section.
    NameValueCollection appSettings = ConfigurationManager.AppSettings;
    // Get the AppSettings section elements.
    Console.WriteLine();
    Console.WriteLine("Using AppSettings property.");
    Console.WriteLine("Application settings:");
    if (appSettings.Count == 0)
    {
      Console.WriteLine("[ReadAppSettings: {0}]",
      "AppSettings is empty Use GetSection command first.");
    }
    for (int i = 0; i < appSettings.Count; i++)
    {
      Console.WriteLine("#{0} Key: {1} Value: {2}",i, appSettings.GetKey(i), appSettings[i]);
    }
  }
  catch (ConfigurationErrorsException e)
  {
    Console.WriteLine("[ReadAppSettings: {0}]", e.ToString());
  }
}
  [1]: http://msdn.microsoft.com/en-us/library/system.configuration.configurationmanager.appsettings%28v=vs.100%29.aspx
So, if you want to access the setting `Scenario1.doc`, you would do this:
var value = ConfigurationManager.AppSettings["Scenario1.doc"];
Edit:
As Gabriel GM said in the comments, you will have to add a reference to ```System.Configuration```.
