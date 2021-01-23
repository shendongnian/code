    private void SendData(UserInputParameters stdObj) {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(stdObj.GetType());
        StreamWriter writer = new StreamWriter(webReq.GetRequestStream());
        JavaScriptSerializer jss = new JavaScriptSerializer();
        string yourdata = jss.Deserialize<UserInputParameters>(stdObj);
        writer.Write(yourdata);
        writer.Close();
    }
