    <img src="<%# ReturnEncodedBase64UTF8(Eval("ColumnA")) %>" />
    protected static string ReturnEncodedBase64UTF8(object rawImg)
    {
        string img = "data:image/gif;base64,{0}"; //change image type if need be
        byte[] toEncodeAsBytes = (byte[])rawImg;
        System.Text.Encoding.UTF8.GetBytes(rawImg);
        string returnValue = System.Convert.ToBase64String(rawImg);
        return String.Format(img, returnValue);
    }
