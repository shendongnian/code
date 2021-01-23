    public class CountryLoader : ILoader<Country>
        {
            public List<Country> LoadFromFile(StreamReader input, out List<Country> result, bool trackProgress)
            {
                return LoadFromFile(input, out result, trackProgress, CultureInfo.CurrentCulture);
            }
    
            public List<Country> LoadFromFile(StreamReader input,
                out List<Country> result, bool trackProgress, IFormatProvider format)
            {
                //Method implementation
                result = null;
                return null;
            }
    
            public Country UploadToDb(List<Country> data)
            {
                //Method implementation
                return null;
            }
        }
