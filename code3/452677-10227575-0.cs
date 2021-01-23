        public static string GetDLLPathFromClassID(string classID)
        {
            var regPath = @"\CLSID\" + classID + @"\InProcServer32\";
            return  GetDefaultRegistryValue(Registry.ClassesRoot, regPath);
        }
        public static string GetClassIDFromProgID(string progID)
        {
                var regPath =   progID + @"\CLSID\";
                return  GetDefaultRegistryValue(Registry.ClassesRoot, regPath);
        }
        private static string GetDefaultRegistryValue(RegistryKey rootKey, string regPath)
        {
            try
            {
                var regPermission = new RegistryPermission(RegistryPermissionAccess.Read,
                                                           @"HKEY_CLASSES_ROOT\" + regPath);
                regPermission.Demand();
                using (var regKey = rootKey.OpenSubKey(regPath))
                {
                    if (regKey != null)
                    {
                        string defaultValue = (string) regKey.GetValue("");
                        {
                            return defaultValue;
                        }
                    }
                }
            }catch(Exception e)
            {
               //log error
            }
            return "";
        }
        public static string GetDLLDirectoryFromProgID(string progID)
        {
            var classID = GetClassIDFromProgID(progID);
            var fileName = GetDLLPathFromClassID(classID);
            if(string.IsNullOrEmpty(fileName))
            {
                return "";
            }
            return Path.GetDirectoryName(fileName);
        }
