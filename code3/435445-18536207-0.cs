        private void UpdateQueryString(string queryString, string value)
        {
            PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            isreadonly.SetValue(this.Request.QueryString, false, null);
            this.Request.QueryString.Set(queryString, value);
            isreadonly.SetValue(this.Request.QueryString, true, null);
        }
