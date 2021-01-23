    public static void PaypalThirdPartyPayNowButtonTest()
    {
        int bvCount = 0; //L_BUTTONVAR counter
        Dictionary<string, string> NVP = new Dictionary<string, string>(); //Api Name-Value-Pair parameters
        //paypal SANDBOX server
        string paypalApiServerUrl = "https://api-3t.sandbox.paypal.com/nvp";
        
        //Api credentials of YOUR business paypal account 
        string yourApiUsername = "aso_1273063882_biz_api3.megatesto.it";
        string yourApiPassword = "1273063582";
        string yourApiSignature = "A22sd7623RGUsduDHDSFU57N7dfhfS23DUYVhdf85du8S6FJ6D5bfoh5";
        
        //Your CUSTOMER identification data
        string customerEmailID = "MyCustomer_143363961_biz@megatesto.it";
        string customerMerchantID = "3S4EF7BI96YHS";
        
        //use YOUR identification data
        NVP.Add("USER", yourApiUsername);
        NVP.Add("PWD", yourApiPassword);
        NVP.Add("SIGNATURE", yourApiSignature);
        
        //use your CUSTOMER identification data
        NVP.Add("SUBJECT", customerEmailID);
        bvCount++; NVP.Add("L_BUTTONVAR" + bvCount.ToString() , "business=" + customerMerchantID);
        //Api method name and version
        NVP.Add("METHOD", "BMCreateButton");
        NVP.Add("VERSION", "85.0");
        
        //method specific parameters
        NVP.Add("BUTTONCODE", "ENCRYPTED");
        NVP.Add("BUTTONTYPE", "BUYNOW");
        NVP.Add("BUTTONSUBTYPE", "PRODUCTS");
        
        //Buynow button specific parameters
        bvCount++; NVP.Add("L_BUTTONVAR" + bvCount.ToString() , "lc=IT");
        bvCount++; NVP.Add("L_BUTTONVAR" + bvCount.ToString() , "button_subtype=PRODUCTS");
        bvCount++; NVP.Add("L_BUTTONVAR" + bvCount.ToString() , "item_name=Test_product");
        bvCount++; NVP.Add("L_BUTTONVAR" + bvCount.ToString() , "item_number=123456");
        bvCount++; NVP.Add("L_BUTTONVAR" + bvCount.ToString() , "amount=12.00");
        bvCount++; NVP.Add("L_BUTTONVAR" + bvCount.ToString() , "currency_code=EUR");
        bvCount++; NVP.Add("L_BUTTONVAR" + bvCount.ToString() , "quantity=1");
        //bvCount = bvCount + 1 : NVP.Add("L_BUTTONVAR" & bvCount, "cmd=_s-xclick")  //DON'T specify the cmd parameter, if you specify it, it wont work, paypal will give you an error
        //build the parameter string
        StringBuilder paramBuilder = new StringBuilder();
        foreach (KeyValuePair<string, string> kv in NVP)
        {
            string st = kv.Key + "=" + System.Web.HttpUtility.UrlEncode(kv.Value) + "&";
            paramBuilder.Append(st);
        }
        string param = paramBuilder.ToString();
        param = param.Substring(0, param.Length - 1); //remove the last '&'
        //Create web request and web response objects, make sure you using the correct server (sandbox/live)
        System.Net.HttpWebRequest wrWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(paypalApiServerUrl);
        wrWebRequest.Method = "POST";
        System.IO.StreamWriter requestWriter = new System.IO.StreamWriter(wrWebRequest.GetRequestStream());
        requestWriter.Write(param);
        requestWriter.Close();
        //Get the responseReader
        System.IO.StreamReader responseReader = new System.IO.StreamReader(wrWebRequest.GetResponse().GetResponseStream());
        string responseData = responseReader.ReadToEnd();
        responseReader.Close();
        //url-decode the results
        string result = System.Web.HttpUtility.UrlDecode(responseData);
          
        string formattedResult = "Request on " + paypalApiServerUrl + "\r\n" + System.Web.HttpUtility.UrlDecode(param.Replace("&", "\r\n  ")) + "\r\n\r\nResult:\r\n" + System.Web.HttpUtility.UrlDecode(responseData.Replace("&", "\r\n  ")) + "\r\n\r\n--------------------------------------\r\n";
          
        //show the results
        System.Diagnostics.Trace.WriteLine(formattedResult);
        System.Windows.Forms.MessageBox.Show(formattedResult);
    }
