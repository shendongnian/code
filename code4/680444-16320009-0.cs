    public string EncodeData(string sData)
    {
    	try {
    		byte[] encData_byte = new byte[sData.Length];
    		encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
    		string encodedData = Convert.ToBase64String(encData_byte);
    		return encodedData;
    	} catch (Exception ex) {
    		throw new Exception("Error in base64Encode" + ex.Message);
    	}
    }
