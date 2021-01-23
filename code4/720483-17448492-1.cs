    public static SpotifySession Create(SpotifySessionConfig config)
    {
        IntPtr sessionPtr = IntPtr.Zero;
        IntPtr listenerToken;
        using (var cacheLocation = SpotifyMarshalling.StringToUtf8(config.CacheLocation))
        using (var settingsLocation = SpotifyMarshalling.StringToUtf8(config.SettingsLocation))
        using (var userAgent = SpotifyMarshalling.StringToUtf8(config.UserAgent))
        using (var deviceId = SpotifyMarshalling.StringToUtf8(config.DeviceId))
        using (var proxy = SpotifyMarshalling.StringToUtf8(config.Proxy))
        using (var proxyUsername = SpotifyMarshalling.StringToUtf8(config.ProxyUsername))
        using (var proxyPassword = SpotifyMarshalling.StringToUtf8(config.ProxyPassword))
        using (var traceFile = SpotifyMarshalling.StringToUtf8(config.TraceFile))
        {
            IntPtr appKeyPtr = IntPtr.Zero;
            listenerToken = ListenerTable.PutUniqueObject(config.Listener, config.UserData);
            try
            {
                NativeCallbackAllocation.AddRef();
                byte[] appkey = config.ApplicationKey;
                appKeyPtr = Marshal.AllocHGlobal(appkey.Length);
                Marshal.Copy(config.ApplicationKey, 0, appKeyPtr, appkey.Length);
                sp_session_config nativeConfig = new sp_session_config {
                    api_version = config.ApiVersion,
                    cache_location = cacheLocation.IntPtr,
                    settings_location = settingsLocation.IntPtr,
                    application_key = appKeyPtr,
                    application_key_size = (UIntPtr)appkey.Length,
                    user_agent = userAgent.IntPtr,
                    callbacks = SessionDelegates.CallbacksPtr,
                    userdata = listenerToken,
                    compress_playlists = config.CompressPlaylists,
                    dont_save_metadata_for_playlists = config.DontSaveMetadataForPlaylists,
                    initially_unload_playlists = config.InitiallyUnloadPlaylists,
                    device_id = deviceId.IntPtr,
                    proxy = proxy.IntPtr,
                    proxy_username = proxyUsername.IntPtr,
                    proxy_password = proxyPassword.IntPtr,
                    tracefile = traceFile.IntPtr,
                };
                // Note: sp_session_create will invoke a callback, so it's important that
                // we have already done ListenerTable.PutUniqueObject before this point.
                var error = NativeMethods.sp_session_create(ref nativeConfig, ref sessionPtr);
                SpotifyMarshalling.CheckError(error);
            }
            catch
            {
                ListenerTable.ReleaseObject(listenerToken);
                NativeCallbackAllocation.ReleaseRef();
                throw;
            }
            finally
            {
                if (appKeyPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(appKeyPtr);
                }
            }
        }
        
        SpotifySession session = SessionTable.GetUniqueObject(sessionPtr);
        session.Listener = config.Listener;
        session.UserData = config.UserData;
        session.ListenerToken = listenerToken;
        return session;
    }
