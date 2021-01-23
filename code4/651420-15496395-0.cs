        COPYDATASTRUCT sentPara = new COPYDATASTRUCT();
    Type mytype = sentPara.GetType();
    sentPara = (COPYDATASTRUCT)message.GetLParam(mytype);
    var parametersDecoded = System.Text.Encoding.Default.GetString(sentPara.lpData);
    string[] parameters = parametersDecoded.Split(',');
