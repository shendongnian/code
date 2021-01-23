    public static class HelperClass
    {
        public static string FrenchSave(B frenchInput)
        {
            
            string result = string.Format("ID = {0}; Name = {1}; City = {2}", frenchInput.Id, frenchInput.Nom, frenchInput.ville);
            return result;
        }
        public static string EnglishSave(A englishInput)
        {
            string result = string.Format("ID = {0}; Name = {1}; City = {2}", englishInput.Id, englishInput.name, englishInput.city);
            return result;
        }
    }
