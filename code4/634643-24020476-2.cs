            internal static void ReportCrash(string message, string stack)
        {
            //Debug.Log("Report Crash");
            var errorMessage = new StringBuilder();
            errorMessage.AppendLine("FreeCell Quest " + Application.platform);
            errorMessage.AppendLine();
            errorMessage.AppendLine(message);
            errorMessage.AppendLine(stack);
            //if (exception.InnerException != null) {
            //    errorMessage.Append("\n\n ***INNER EXCEPTION*** \n");
            //    errorMessage.Append(exception.InnerException.ToString());
            //}
            errorMessage.AppendFormat
            (
                "{0} {1} {2} {3}\n{4}, {5}, {6}, {7}x {8}\n{9}x{10} {11}dpi FullScreen {12}, {13}, {14} vmem: {15} Fill: {16} Max Texture: {17}\n\nScene {18}, Unity Version {19}, Ads Disabled {18}",
                SystemInfo.deviceModel,
                SystemInfo.deviceName,
                SystemInfo.deviceType,
                SystemInfo.deviceUniqueIdentifier,
                SystemInfo.operatingSystem,
                Localization.language,
                SystemInfo.systemMemorySize,
                SystemInfo.processorCount,
                SystemInfo.processorType,
                Screen.currentResolution.width,
                Screen.currentResolution.height,
                Screen.dpi,
                Screen.fullScreen,
                SystemInfo.graphicsDeviceName,
                SystemInfo.graphicsDeviceVendor,
                SystemInfo.graphicsMemorySize,
                SystemInfo.graphicsPixelFillrate,
                SystemInfo.maxTextureSize,
                Application.loadedLevelName,
                Application.unityVersion,
                GameSettings.AdsDisabled
            );
            //if (Main.Player != null) {
            //    errorMessage.Append("\n\n ***PLAYER*** \n");
            //    errorMessage.Append(XamlServices.Save(Main.Player));
            //}
            try {
                using (var client = new WebClient()) {
                    var arguments = new NameValueCollection();
                    //if (loginResult != null)
                    //    arguments.Add("SessionId", loginResult.SessionId.ToString());
                    arguments.Add("report", errorMessage.ToString());
                    var result = Encoding.ASCII.GetString(client.UploadValues(serviceAddress + "/ReportCrash", arguments));
                    //Debug.Log(result);
                }
            } catch (WebException e) {
                Debug.Log("Report Crash: " + e.ToString());
            }
        }
