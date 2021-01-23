    public static void Connect()
    {
        // Configure the connection.
        ICAClientClass ica = new ICAClientClass();
        ica.Application = string.Empty;
        ica.InitialProgram = "#Name of Citrix application to launch";
        ica.Launch = true;
        ica.Domain = Environment.UserDomainName;
        ica.DesiredColor = ICAColorDepth.Color24Bit;
        ica.OutputMode = OutputMode.OutputModeNormal;
        ica.MaximizeWindow();
        ica.ClientAudio = true;
        ica.AudioBandwidthLimit = ICASoundQuality.SoundQualityMedium;
        ica.Compress = true;
        ica.ScreenPercent = 100;
        ica.TransportDriver = "TCP/IP";
        ica.WinstationDriver = "ICA 3.0";
        ica.SSLEnable = false;
        ica.SSLCiphers = "ALL";
        ica.SSLProxyHost = "*:443";
        ica.EncryptionLevelSession = "EncRC5-128";
    
        // Citrix server name or IP
        ica.Address = "x.x.x.x"; 
    
        // Setup handler for disconnect event.
        ica.OnDisconnect += ica_OnDisconnect;
   
        // Initiate the connection.
        ica.Connect();
    }
    
    private static void ica_OnDisconnect()
    {
        Console.WriteLine("ica_OnDisconnect");
    }
