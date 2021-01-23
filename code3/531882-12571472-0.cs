      string BuildData(NameValueCollection getData, Encoding enc)
        {
            StringBuilder urldata = new StringBuilder();
            for (int i = 0; i < getData.Count; i++)
            {
                if (i > 0) urldata.Append("&");
                urldata.Append(getData.Keys[i] + "=" + HttpUtility.UrlEncode(enc.GetBytes(getData[i])));
            }
            return urldata.ToString();
        }
