            try
            {
                objResponse = objRequest.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                objResponse = ex.Response as HttpWebResponse;
            }
            finally
