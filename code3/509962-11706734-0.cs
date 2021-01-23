    private void Put(XElement article)
    {
        Stream data = null;
        try
        {
            string finalXML = article.ToString(SaveOptions.DisableFormatting);
            HttpWebRequest reqToUpdate = (HttpWebRequest)WebRequest.Create(url);
            reqToUpdate.ContentType = "text/xml; encoding=UTF-8";
            reqToUpdate.Method = "PUT";
            byte[] bytes = new UTF8Encoding().GetBytes(finalXML);
            reqToUpdate.ContentLength = bytes.Length;
            data = reqToUpdate.GetRequestStream();
            data.Write(bytes, 0, bytes.Length);
        }
        catch (Exception error)
        {
            MessageBox.Show(error.Message);
        }
        finally
        {
            if (null != data)
                data.Close();
        }
    }
