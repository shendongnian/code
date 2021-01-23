    internal class InternetExplorerFeatureControl
    {
        private static readonly Lazy<InternetExplorerFeatureControl> LazyInstance = new Lazy<InternetExplorerFeatureControl>(() => new InternetExplorerFeatureControl());
        private const string RegistryLocation = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl";
        private readonly RegistryView _registryView = Environment.Is64BitOperatingSystem && Environment.Is64BitProcess ? RegistryView.Registry64 : RegistryView.Registry32;
        private readonly string _processName;
        private readonly Version _version;
        #region Feature Control Strings (A)
        private const string FeatureRestrictAboutProtocolIe7 = @"FEATURE_RESTRICT_ABOUT_PROTOCOL_IE7";
        private const string FeatureRestrictAboutProtocol = @"FEATURE_RESTRICT_ABOUT_PROTOCOL";
        #endregion
        #region Feature Control Strings (B)
        private const string FeatureBrowserEmulation = @"FEATURE_BROWSER_EMULATION";
        #endregion
        #region Feature Control Strings (G)
        private const string FeatureGpuRendering = @"FEATURE_GPU_RENDERING";
        #endregion
        #region Feature Control Strings (L)
        private const string FeatureBlockLmzScript = @"FEATURE_BLOCK_LMZ_SCRIPT";
        #endregion
       
        internal InternetExplorerFeatureControl()
        {
            _processName = $"{Process.GetCurrentProcess().ProcessName}.exe";
            using (var webBrowser = new WebBrowser())
                _version = webBrowser.Version;
        }
        internal static InternetExplorerFeatureControl Instance => LazyInstance.Value;
        internal RegistryHive RegistryHive { get; set; } = RegistryHive.CurrentUser;
        private int GetFeatureControl(string featureControl)
        {
            using (var currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, _registryView))
            {
                using (var key = currentUser.CreateSubKey($"{RegistryLocation}\\{featureControl}", false))
                {
                    if (key.GetValue(_processName) is int value)
                    {
                        return value;
                    }
                    return -1;
                }
            }
        }
        private void SetFeatureControl(string featureControl, int value)
        {
            using (var currentUser = RegistryKey.OpenBaseKey(RegistryHive, _registryView))
            {
                using (var key = currentUser.CreateSubKey($"{RegistryLocation}\\{featureControl}", true))
                {
                    key.SetValue(_processName, value, RegistryValueKind.DWord);
                }
            }
        }
        #region Internet Feature Controls (A)
        /// <summary>
        /// Windows Internet Explorer 8 and later. When enabled, feature disables the "about:" protocol. For security reasons, applications that host the WebBrowser Control are strongly encouraged to enable this feature.
        /// By default, this feature is enabled for Windows Internet Explorer and disabled for applications hosting the WebBrowser Control.To enable this feature using the registry, add the name of your executable file to the following setting.
        /// </summary>
        internal bool AboutProtocolRestriction
        {
            get
            {
                if (_version.Major < 8)
                    throw new NotSupportedException($"{AboutProtocolRestriction} requires Internet Explorer 8 and Later.");
                var releaseVersion = new Version(8, 0, 6001, 18702);
                return Convert.ToBoolean(GetFeatureControl(_version >= releaseVersion ? FeatureRestrictAboutProtocolIe7 : FeatureRestrictAboutProtocol));
            }
            set
            {
                if (_version.Major < 8)
                    throw new NotSupportedException($"{AboutProtocolRestriction} requires Internet Explorer 8 and Later.");
                var releaseVersion = new Version(8, 0, 6001, 18702);
                SetFeatureControl(_version >= releaseVersion ? FeatureRestrictAboutProtocolIe7 : FeatureRestrictAboutProtocol, Convert.ToInt16(value));
            }
        }
        #endregion
        #region Internet Feature Controls (B)
        /// <summary>
        /// Windows Internet Explorer 8 and later. Defines the default emulation mode for Internet Explorer and supports the following values.
        /// </summary>
        internal DocumentMode BrowserEmulation
        {
            get
            {
                if (_version.Major < 8)
                    throw new NotSupportedException($"{nameof(BrowserEmulation)} requires Internet Explorer 8 and Later.");
                var value = GetFeatureControl(FeatureBrowserEmulation);
                if (Enum.IsDefined(typeof(DocumentMode), value))
                {
                    return (DocumentMode)value;
                }
                return DocumentMode.NotSet;
            }
            set
            {
                if (_version.Major < 8)
                    throw new NotSupportedException($"{nameof(BrowserEmulation)} requires Internet Explorer 8 and Later.");
                var tmp = value;
                if (value == DocumentMode.DefaultRespectDocType)
                    tmp = DefaultRespectDocType;
                else if (value == DocumentMode.DefaultOverrideDocType)
                    tmp = DefaultOverrideDocType;
                SetFeatureControl(FeatureBrowserEmulation, (int)tmp);
            }
        }
        #endregion
        #region Internet Feature Controls (G)
        /// <summary>
        /// Internet Explorer 9. Enables Internet Explorer to use a graphics processing unit (GPU) to render content. This dramatically improves performance for webpages that are rich in graphics.
        /// By default, this feature is enabled for Internet Explorer and disabled for applications hosting the WebBrowser Control.To enable this feature by using the registry, add the name of your executable file to the following setting.
        /// Note: GPU rendering relies heavily on the quality of your video drivers. If you encounter problems running Internet Explorer with GPU rendering enabled, you should verify that your video drivers are up to date and that they support hardware accelerated graphics.
        /// </summary>
        internal bool GpuRendering
        {
            get
            {
                if (_version.Major < 9)
                    throw new NotSupportedException($"{nameof(GpuRendering)} requires Internet Explorer 9 and Later.");
                return Convert.ToBoolean(GetFeatureControl(FeatureGpuRendering));
            }
            set
            {
                if (_version.Major < 9)
                    throw new NotSupportedException($"{nameof(GpuRendering)} requires Internet Explorer 9 and Later.");
                SetFeatureControl(FeatureGpuRendering, Convert.ToInt16(value));
            }
        }
        #endregion
        #region Internet Feature Controls (L)
        /// <summary>
        /// Internet Explorer 7 and later. When enabled, feature allows scripts stored in the Local Machine zone to be run only in webpages loaded from the Local Machine zone or by webpages hosted by sites in the Trusted Sites list. For more information, see Security and Compatibility in Internet Explorer 7.
        /// By default, this feature is enabled for Internet Explorer and disabled for applications hosting the WebBrowser Control.To enable this feature by using the registry, add the name of your executable file to the following setting.
        /// </summary>
        internal bool LocalScriptBlocking
        {
            get
            {
                if (_version.Major < 7)
                    throw new NotSupportedException($"{nameof(LocalScriptBlocking)} requires Internet Explorer 7 and Later.");
                return Convert.ToBoolean(GetFeatureControl(FeatureBlockLmzScript));
            }
            set
            {
                if (_version.Major < 7)
                    throw new NotSupportedException($"{nameof(LocalScriptBlocking)} requires Internet Explorer 7 and Later.");
                SetFeatureControl(FeatureBlockLmzScript, Convert.ToInt16(value));
            }
        }
        #endregion
        private DocumentMode DefaultRespectDocType
        {
            get
            {
                if (_version.Major >= 11)
                    return DocumentMode.InternetExplorer11RespectDocType;
                switch (_version.Major)
                {
                    case 10:
                        return DocumentMode.InternetExplorer10RespectDocType;
                    case 9:
                        return DocumentMode.InternetExplorer9RespectDocType;
                    case 8:
                        return DocumentMode.InternetExplorer8RespectDocType;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        private DocumentMode DefaultOverrideDocType
        {
            get
            {
                if (_version.Major >= 11)
                    return DocumentMode.InternetExplorer11OverrideDocType;
                switch (_version.Major)
                {
                    case 10:
                        return DocumentMode.InternetExplorer10OverrideDocType;
                    case 9:
                        return DocumentMode.InternetExplorer9OverrideDocType;
                    case 8:
                        return DocumentMode.InternetExplorer8OverrideDocType;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
    internal enum DocumentMode
    {
        NotSet = -1,
        [Description("Webpages containing standards-based !DOCTYPE directives are displayed in IE latest installed version mode.")]
        DefaultRespectDocType,
        [Description("Webpages are displayed in IE latest installed version mode, regardless of the declared !DOCTYPE directive.  Failing to declare a !DOCTYPE directive could causes the page to load in Quirks.")]
        DefaultOverrideDocType,
        [Description(
            "Internet Explorer 11. Webpages are displayed in IE11 edge mode, regardless of the declared !DOCTYPE directive. Failing to declare a !DOCTYPE directive causes the page to load in Quirks."
        )] InternetExplorer11OverrideDocType = 11001,
        [Description(
            "IE11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 edge mode. Default value for IE11."
        )] InternetExplorer11RespectDocType = 11000,
        [Description(
            "Internet Explorer 10. Webpages are displayed in IE10 Standards mode, regardless of the !DOCTYPE directive."
        )] InternetExplorer10OverrideDocType = 10001,
        [Description(
            "Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode. Default value for Internet Explorer 10."
        )] InternetExplorer10RespectDocType = 10000,
        [Description(
            "Windows Internet Explorer 9. Webpages are displayed in IE9 Standards mode, regardless of the declared !DOCTYPE directive. Failing to declare a !DOCTYPE directive causes the page to load in Quirks."
        )] InternetExplorer9OverrideDocType = 9999,
        [Description(
            "Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.\r\n" +
            "Important  In Internet Explorer 10, Webpages containing standards - based !DOCTYPE directives are displayed in IE10 Standards mode."
        )] InternetExplorer9RespectDocType = 9000,
        [Description(
            "Webpages are displayed in IE8 Standards mode, regardless of the declared !DOCTYPE directive. Failing to declare a !DOCTYPE directive causes the page to load in Quirks."
        )] InternetExplorer8OverrideDocType = 8888,
        [Description(
            "Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8\r\n" +
            "Important  In Internet Explorer 10, Webpages containing standards - based !DOCTYPE directives are displayed in IE10 Standards mode."
        )] InternetExplorer8RespectDocType = 8000,
        [Description(
            "Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control."
        )] InternetExplorer7RespectDocType = 7000
    }
