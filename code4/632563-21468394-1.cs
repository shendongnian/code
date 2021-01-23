    namespace YourApp
    {
        using Windows.Storage;
        using Windows.UI.Popups;
        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.Threading.Tasks;
        public class LittleWatson
        {
            private const string settingname = "LittleWatsonDetails";
            private const string email = "mailto:?to=you@example.com&subject=YourApp auto-generated problem report&body=";
            private const string extra = "extra", message = "message", stacktrace = "stacktrace";
            internal static void ReportException(Exception ex, string extraData)
            {
                ApplicationData.Current.LocalSettings.CreateContainer(settingname, Windows.Storage.ApplicationDataCreateDisposition.Always);
                var exceptionValues = ApplicationData.Current.LocalSettings.Containers[settingname].Values;
                exceptionValues[extra] = extraData;
                exceptionValues[message] = ex.Message;
                exceptionValues[stacktrace] = ex.StackTrace;
            }
            internal async static Task CheckForPreviousException()
            {
                var container = ApplicationData.Current.LocalSettings.Containers;
                try
                {
                    var exceptionValues = container[settingname].Values;
                    string extraData = exceptionValues[extra] as string;
                    string messageData = exceptionValues[message] as string;
                    string stacktraceData = exceptionValues[stacktrace] as string;
                    var sb = new StringBuilder();
                    sb.AppendLine(extraData);
                    sb.AppendLine(messageData);
                    sb.AppendLine(stacktraceData);
                    string contents = sb.ToString();
                    SafeDeleteLog();
                    if (stacktraceData != null && stacktraceData.Length > 0)
                    {
                        var dialog = new MessageDialog("A problem occured the last time you ran this application. Would you like to report it so that we can fix the error?", "Error Report")
                        {
                            CancelCommandIndex = 1,
                            DefaultCommandIndex = 0
                        };
                        dialog.Commands.Add(new UICommand("Send", async delegate
                        {
                            var mailToSend = email.ToString();
                            mailToSend += contents;
                            var mailto = new Uri(mailToSend);
                            await Windows.System.Launcher.LaunchUriAsync(mailto);
                        }));
                        dialog.Commands.Add(new UICommand("Cancel"));
                        await dialog.ShowAsync();
                    }
                }
                catch (KeyNotFoundException)
                {
                    // KeyNotFoundException will fire if we've not ever had crash data. No worries!
                }
            }
            private static void SafeDeleteLog()
            {
                ApplicationData.Current.LocalSettings.CreateContainer(settingname, Windows.Storage.ApplicationDataCreateDisposition.Always);
                var exceptionValues = ApplicationData.Current.LocalSettings.Containers[settingname].Values;
                exceptionValues[extra] = string.Empty;
                exceptionValues[message] = string.Empty;
                exceptionValues[stacktrace] = string.Empty;
            }
        }
    }
