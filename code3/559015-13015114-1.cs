    `List<XmlRpcStruct> dic = new List<XmlRpcStruct>();
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
           List<XmlRpcStruct> prod = new List<XmlRpcStruct>();
           prod.Add("sku", dt1.Rows[i][0].ToString());
           prod.Add("quantity", dt1.Rows[i][1].ToString());
           dic.Add("products", prod); //this line might be a culprit
        }
        
        object orderID = proxy.SubmitOrder(dic, custID, accessKey);`
