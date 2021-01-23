        /// <summary>
        /// Gets a single key Value from a Json filled cookie with 'cookiename','key' 
        /// </summary>
        public static string GetSpecialCookieKeyVal(string _CookieName, string _key)
        {
            //CALL COOKIE VALUES INTO DICTIONARY
            Dictionary<string, string> dictCookie =
            JsonConvert.DeserializeObject<Dictionary<string, string>>
             (MyCookinator.Get(_CookieName));
            
            string value;
            if (dictCookie.TryGetValue( _key, out value))
            {
                return value;
            }
            else
            {
                return "0";
            }
        }
