    void Main()
    {
        var ini = new IniFile(@"d:\temp\test.ini");
        ini.WriteValue("Section", "Key", "Value");
        ini.ReadValue("Section", "Key").Dump();
    
        ini["Main", "Key2"] = "Test";
        ini["Main", "Key2"].Dump();
    }
    
    [DllImport("kernel32.dll", CharSet=CharSet.Unicode)]
    static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName,string lpDefault, StringBuilder lpReturnedString, uint nSize,string lpFileName);
    
    [DllImport("kernel32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
    
    public class IniFile
    {
        const int MAX_SIZE = 1024;
    
        private readonly string _FilePath;
    
        public IniFile(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");
    
            _FilePath = filePath;
        }
    
        public string this[string section, string key]
        {
            get
            {
                return ReadValue(section, key);
            }
    
            set
            {
                WriteValue(section, key, value);
            }
        }
    
        public string ReadValue(string section, string key, string defaultValue = null)
        {
            var result = new StringBuilder(MAX_SIZE);
            if (GetPrivateProfileString(section, key, defaultValue ?? string.Empty, result, (uint)result.Capacity, _FilePath) > 0)
                return result.ToString();
    
            throw new Win32Exception();
        }
    
        public void WriteValue(string section, string key, string value)
        {
            if (!WritePrivateProfileString(section, key, value, _FilePath))
                throw new Win32Exception();
        }
    }
