        // just took enums from NTDDNDIS.H file...
    enum NDIS_802_11_WEP_STATUS
    {
        Ndis802_11WEPEnabled,
        Ndis802_11Encryption1Enabled = Ndis802_11WEPEnabled,
        Ndis802_11WEPDisabled,
        Ndis802_11EncryptionDisabled = Ndis802_11WEPDisabled,
        Ndis802_11WEPKeyAbsent,
        Ndis802_11Encryption1KeyAbsent = Ndis802_11WEPKeyAbsent,
        Ndis802_11WEPNotSupported,
        Ndis802_11EncryptionNotSupported = Ndis802_11WEPNotSupported,
        Ndis802_11Encryption2Enabled,
        Ndis802_11Encryption2KeyAbsent,
        Ndis802_11Encryption3Enabled,
        Ndis802_11Encryption3KeyAbsent
    };
    enum NDIS_802_11_NETWORK_INFRASTRUCTURE
    {
        Ndis802_11IBSS,
        Ndis802_11Infrastructure,
        Ndis802_11AutoUnknown,
        Ndis802_11InfrastructureMax         // Not a real value, defined as upper bound
    };
    enum NDIS_802_11_NETWORK_TYPE
    {
        Ndis802_11FH,
        Ndis802_11DS,
        Ndis802_11OFDM5,			// Added new types for OFDM 5G and 2.4G
        Ndis802_11OFDM24,
        Ndis802_11NetworkTypeMax    // not a real type, defined as an upper bound
    };
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct APInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string _ssid;	// SSID of the AP
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string _mac;	// MAC address of the AP
        //[MarshalAs(UnmanagedType.U4)]
        public int _rssi;	// signal strength in dB
        //[MarshalAs(UnmanagedType.U4)]
        public uint _wepStatus;
        [MarshalAs(UnmanagedType.I4)]
        public NDIS_802_11_NETWORK_INFRASTRUCTURE _networkInfrastructure;
        [MarshalAs(UnmanagedType.I4)]
        public NDIS_802_11_NETWORK_TYPE _networkType;
        [MarshalAs(UnmanagedType.U4)]
        public uint BeaconPeriod;		// units are Kusec
        [MarshalAs(UnmanagedType.U4)]
        public uint DSConfig;			// Frequency, units are kHz
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] _rates;          // MSDN: Each byte describes a single rate in units of 0.5 Mbps
    }
    
    public class AccessPoint
    {
        //  if the power level (in dBm) lower that this, then the signal is weak
        const int STRONG_WEEK_dBm_THRESHOLD = -70;
        public static bool IsSignalWeak(int SignalStrengthdBm)
        {
            return SignalStrengthdBm < STRONG_WEEK_dBm_THRESHOLD;
        }
        internal AccessPoint(APInfo apInfo)
        {
            _ssid = apInfo._ssid;
            _mac = apInfo._mac;
            _rssi = apInfo._rssi;
            _wepStatus = apInfo._wepStatus;
            _networkInfrastructure = apInfo._networkInfrastructure;
            _networkType = apInfo._networkType;
            BeaconPeriod = apInfo.BeaconPeriod;
            DSConfig = apInfo.DSConfig;
            _rates = apInfo._rates;
        }
        private string _ssid;	// SSID of the AP
        private string _mac;	// MAC address of the AP
        private int _rssi;	// signal strength in dB
        private uint _wepStatus;
        private NDIS_802_11_NETWORK_INFRASTRUCTURE _networkInfrastructure;
        private NDIS_802_11_NETWORK_TYPE _networkType;
        private uint BeaconPeriod;		// units are Kusec
        private uint DSConfig;			// Frequency, units are kHz
        private byte[] _rates;          // MSDN: Each byte describes a single rate in units of 0.5 Mbps
        public bool IsEncrypted
        {
            get
            {
                return _wepStatus != 0;
            }
        }
        /// <summary>
        /// Beacon Interval in ms
        /// </summary>
        public ulong BeaconInterval
        {
            get { return BeaconPeriod; }
        }
        /// <summary>
        /// Frequency in MHz
        /// </summary>
        public ulong Frequency
        {
            get { return (DSConfig / 1000); }
        }
        /// <summary>
        /// Supported Rates by AP. Part of them belongs to Basic Rate Set.
        /// </summary>
        public string Rates
        {
            get
            {
                Array.Sort(_rates);
                string basicRateSet = "", notBasicRateSet = "";
                for (int i = 0; i < _rates.Length; i++)
                {
                    if (_rates[i] == 0)
                        continue;
                    // Each supported rate from the BSSBasicRateSet is encoded as a byte with the most significant bit (bit 7) set to 1. 
                    if ((_rates[i] & (1 << 7)) > 0)
                        basicRateSet += ((_rates[i] - 128) / 2).ToString() + "; ";
                    // Rates that are not included in the BSSBasicRateSet are encoded with the most significant bit set to zero. 
                    else
                        notBasicRateSet += (_rates[i] / 2).ToString() + "; ";
                }
                return "BSSBasicRateSet: {" + basicRateSet + "}. other: {" + notBasicRateSet + "}";
            }
        }
        /// <summary>
        /// Number of wireless channel
        /// </summary>
        public ulong Channel
        {
            get
            {
                ulong centralFreqMHz = DSConfig / 1000;
                if (centralFreqMHz > 2400 && centralFreqMHz < 2500)      // then this is 802.11b/g
                {
                    /*
                    Regional allocated use of 802.11b/g channels  
                        1 to 11 -- North America (USA and Canada) 
                        1 to 13 -- Austria, Belgium, Denmark, Finland, France, Germany, Greece, Iceland, Ireland, Italy, Liechtenstein, Luxembourg,  Netherlands, Norway, Portugal, Spain, Sweden, Switzerland, United Kingdom.
                        1 to 14 -- Japan, China, Hong Kong, Philippines, Taiwan, Thailand, Singapore, South Korea 
                    */
                    switch (centralFreqMHz)
                    {
                        case 2412:
                            return 1;
                        case 2417:
                            return 2;
                        case 2422:
                            return 3;
                        case 2427:
                            return 4;
                        case 2432:
                            return 5;
                        case 2437:
                            return 6;
                        case 2442:
                            return 7;
                        case 2447:
                            return 8;
                        case 2452:
                            return 9;
                        case 2457:
                            return 10;
                        case 2462:
                            return 11;
                        case 2467:
                            return 12;
                        case 2472:
                            return 13;
                        case 2484:
                            return 14;
                        default:
                            return 0;
                    }
                }
                else if (centralFreqMHz > 5100 && centralFreqMHz < 5900)       // this is 802.11a
                {
                    switch (centralFreqMHz)
                    {
                        case 5170:
                            return 34;
                        case 5180:
                            return 36;
                        case 5190:
                            return 38;
                        case 5200:
                            return 40;
                        case 5210:
                            return 42;
                        case 5220:
                            return 44;
                        case 5230:
                            return 46;
                        case 5240:
                            return 48;
                        case 5260:
                            return 52;
                        case 5280:
                            return 56;
                        case 5300:
                            return 60;
                        case 5320:
                            return 64;
                        case 5500:
                            return 100;
                        case 5520:
                            return 104;
                        case 5540:
                            return 108;
                        case 5560:
                            return 112;
                        case 5580:
                            return 116;
                        case 5600:
                            return 120;
                        case 5620:
                            return 124;
                        case 5640:
                            return 128;
                        case 5660:
                            return 132;
                        case 5680:
                            return 136;
                        case 5700:
                            return 140;
                        case 5745:
                            return 149;
                        case 5765:
                            return 153;
                        case 5785:
                            return 157;
                        case 5805:
                            return 161;
                        default:
                            return 0;
                    }
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// SSID of the AP
        /// </summary>
        public string SSID
        {
            get { return _ssid; }
        }
        /// <summary>
        ///  MAC address "XX-XX-XX-XX-XX-XX"
        /// </summary>
        public string MAC
        {
            get { return _mac; }
        }
        /// <summary>
        /// Signal strength in dB
        /// </summary>
        public int SignalStrength
        {
            get { return (int)_rssi; }
        }
        /// <summary>
        /// MSDN:
        /// Specifies a WEP/WPA/WPA2 encryption requirement. A value of 0 indicates that privacy is disabled. 
        /// A value of 1 indicates that privacy is enabled. 
        /// </summary>
        public string WEP
        {
            get { return (_wepStatus == 0 ? "WEP disabled" : "WEP enabled"); }
        }
        /// <summary>
        /// Indicates the physical layer for the AP
        /// </summary>
        public string NetworkType
        {
            get
            {
                if (_networkType == NDIS_802_11_NETWORK_TYPE.Ndis802_11FH)
                    return "frequency-hopping spread-spectrum PHY";
                else if (_networkType == NDIS_802_11_NETWORK_TYPE.Ndis802_11DS)
                    return "direct-sequence spread-spectrum PHY";
                else if (_networkType == NDIS_802_11_NETWORK_TYPE.Ndis802_11OFDM24)
                    return "OFDM 2.4 GHz";
                else if (_networkType == NDIS_802_11_NETWORK_TYPE.Ndis802_11OFDM5)
                    return "OFDM 5 GHz";
                else
                    return "PHY is not FH, nor DS";
            }
        }
        /// <summary>
        /// Indicates current network mode for AP
        /// </summary>
        public string NetworkMode
        {
            get
            {
                if (_networkInfrastructure == NDIS_802_11_NETWORK_INFRASTRUCTURE.Ndis802_11IBSS)
                    return "IBSS (ad hoc) mode";
                else if (_networkInfrastructure == NDIS_802_11_NETWORK_INFRASTRUCTURE.Ndis802_11Infrastructure)
                    return "Infrastructure (ESS) mode";
                else if (_networkInfrastructure == NDIS_802_11_NETWORK_INFRASTRUCTURE.Ndis802_11AutoUnknown)
                    return "Automatic network mode";
                else
                    return "not specified";
            }
        }
    }
