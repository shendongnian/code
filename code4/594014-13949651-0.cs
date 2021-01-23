        public static string GetAsyncPostBackControlID(Page page, HttpRequest request)
        {
            string smUniqueId = ScriptManager.GetCurrent(page).UniqueID;
            string smFieldValue = request.Form[smUniqueId];
            if (!String.IsNullOrEmpty(smFieldValue) && smFieldValue.Contains('|'))
                return smFieldValue.Split('|')[1];
            return String.Empty;
        }
