    public string extract(NameValueCollection myRequest) {
        int loop1;
        StringBuilder processed_data= new StringBuilder();
        // Get names of all forms into a string array.
        String[] arr1 = myRequest.AllKeys;
        for (loop1 = 0; loop1 < arr1.Length; loop1++) 
        {
            data.Append("Form: " + arr1[loop1] + "<br>");
        }
        return processed_data.ToString();
    }
