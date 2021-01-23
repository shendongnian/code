    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.Win32;
    
    namespace MyNamespace
    {
        static class Settings
        {
            private static string _connectionString = @"data source=C:\\database.s3db";
    
            public static string ConnectionString
            {
                get { return GetSetting("_connectionString"); }
                set { _connectionString = value; }
            }
    
            private static string _archives = "";
    
            public static string Archives
            {
                get { return GetSetting("_archives"); }
                set { _archives = value; }
            }
            public static bool CheckDuplicates
            {
                get { return bool.Parse(GetSetting("_checkDuplicates")); }
                set { _checkDuplicates = value; }
            }
    
            private static bool _saveDocks = true;
    
            public static bool SaveDocks
            {
                get { return bool.Parse(GetSetting("_saveDocks")); }
                set { _saveDocks = value; }
            }
            private static Font _font = new Font("Tahoma", 12, GraphicsUnit.Pixel);
    
            public static Font Font
            {
                get
                {
                    var convert = new FontConverter();
                    var value = convert.ConvertFromString(GetSetting("_font"));
                    return (Font) value;
                }
                set { _font = value; }
            }
    
            public static void Save()
            {
                Type type = typeof(Settings);
    
                var registryKey = Registry.CurrentUser.CreateSubKey(string.Format(@"Software\{0}\{1}\Settings", Application.CompanyName, Application.ProductName));
                if (registryKey != null)
                {
                    foreach (var field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Static))
                    {
                        var converter = TypeDescriptor.GetConverter(field.FieldType);
                        var value = converter.ConvertToString(field.GetValue(null));
                        registryKey.SetValue(field.Name, value ?? field.GetValue(null));
                    }
                    registryKey.Close();
                }
            }
    
            public static void SetDefaults()
            {
                var registryKey = Registry.CurrentUser.OpenSubKey(string.Format(@"Software\{0}\{1}\Settings", Application.CompanyName, Application.ProductName));
                if (registryKey == null)
                {
                    Save();
                }
                else
                {
                    registryKey = Registry.CurrentUser.CreateSubKey(string.Format(@"Software\{0}\{1}\Settings", Application.CompanyName, Application.ProductName));
                    if(registryKey == null) return;
                    Type type = typeof(Settings);
                    foreach (var field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Static))
                    {
                        if (registryKey.GetValue(field.Name) != null)
                        {
                            var converter = TypeDescriptor.GetConverter(field.FieldType);
                            var value = converter.ConvertFrom(registryKey.GetValue(field.Name, field.GetValue(null)));
                            field.SetValue(null, value);
                        }
                    }
                    registryKey.Close();
                }
            }
    
            private static string GetSetting(string name)
            {
                var registryKey = Registry.CurrentUser.OpenSubKey(string.Format(@"Software\{0}\{1}\Settings", Application.CompanyName, Application.ProductName));
                if (registryKey != null)
                {
                    if (registryKey.GetValue(name) != null)
                    {
                        return registryKey.GetValue(name).ToString();
                    }
                    registryKey.Close();
                }
                return "";
            }
        }
    }
