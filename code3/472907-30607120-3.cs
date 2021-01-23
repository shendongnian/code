        /// <summary>
        /// This function is designed specifically for producing a 
        /// System.Version object from the Uninstall information
        /// ("Version" key) in the Windows registry for a given app.
        /// </summary>
        /// <param name="input">Using the Registry class to obtain a 
        /// REG_DWORD value for an installed application, 
        /// you are left with an integer as string. Input that here.</param>
        /// <returns>System Version Object (Major, Minor, Build) </returns>
        public static System.Version RegDwordIntegerVersionParse(string input)
        {
            string HexMajor = string.Empty;
            string HexMinor = string.Empty;
            string HexBuild = string.Empty;
            int Major = -1;
            int Minor = -1;
            int Build = -1;
            try
            {
                int decimalVersion = int.Parse(input);
                string hexVersion = decimalVersion.ToString("X");
                // Could also check for alphanumeric...
                if (!string.IsNullOrEmpty(hexVersion) && hexVersion.Length >= 5)
                {
                    HexMajor = hexVersion.Substring(0, 2);
                    HexMinor = hexVersion.Substring(2, 2);
                    // The Build number could be up to 4 characters, but might be less!
                    HexBuild = hexVersion.Substring(4, hexVersion.Length - 4);
                    // Reverse the Little Endian values 
                    HexMajor = HexMajor.Substring(1, 1) + HexMajor.Substring(0, 1);
                    HexMinor = HexMinor.Substring(1, 1) + HexMinor.Substring(0, 1);
                    Major = int.Parse(HexMajor, System.Globalization.NumberStyles.HexNumber);
                    Minor = int.Parse(HexMinor, System.Globalization.NumberStyles.HexNumber);
                    Build = int.Parse(HexBuild, System.Globalization.NumberStyles.HexNumber);
                    return new Version(Major, Minor, Build);
                }
                else return new Version();
            }
            catch (Exception ex) 
            { 
                Error.HandleError(Enums.MessageLevel.Exception, string.Empty, ex);
                return new Version();
            }
        }
