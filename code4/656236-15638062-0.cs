        catch (WebException webEx)
        {
            string errorDetail = string.Empty;
            using (StreamReader streamReader = new StreamReader(webEx.Response.GetResponseStream(), true))
            {
                errorDetail = streamReader.ReadToEnd();
            }
        }
