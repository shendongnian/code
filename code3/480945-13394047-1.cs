    public class CountryFlags {
        public static Stream GetFlagStream(string countryIsoCode2ch)
        {
            var flagname = "Full.DLL.Name.CountryFlags.{0}.png";
            var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                       string.Format(flagname, countryIsoCode2ch));
            
            return rs;
        }
    }
