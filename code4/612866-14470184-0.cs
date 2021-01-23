    private async void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
    {
        minhaSigla = Sigla.Text;
        string result = await GetQuoteAndUpdateTextAsync(minhaSigla);
        tb1.Text = "UIElement-TO-UPDATE";
    }
    private Task<string> GetQuoteAndUpdateTextAsync(string sign)
    {
        string SoapEnvelope = "";
        SoapEnvelope = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
        SoapEnvelope += "<soap:Envelope ";
        SoapEnvelope += "xmlns:xsi = \"http://www.w3.org/2001/XMLSchema-instance\" ";
        SoapEnvelope += "xmlns:xsd= \"http://www.w3.org/2001/XMLSchema\" ";
        SoapEnvelope += "xmlns:soap= \"http://schemas.xmlsoap.org/soap/envelope/\">";
        SoapEnvelope += "<soap:Body>";
        SoapEnvelope += "   <GetQuote xmlns=\"http://www.webserviceX.NET/\"> ";
        SoapEnvelope += "       <symbol>" + sign + "</symbol> ";
        SoapEnvelope += "   </GetQuote> ";
        SoapEnvelope += "</soap:Body>";
        SoapEnvelope += "</soap:Envelope>";
        EndpointAddress endpoint = new EndpointAddress("http://www.webservicex.net/stockquote.asmx");
        BasicHttpBinding basicbinding = new BasicHttpBinding();
        basicbinding.SendTimeout = new TimeSpan(3000000000);
        basicbinding.OpenTimeout = new TimeSpan(3000000000);
        stockbyname.StockQuoteSoapClient sbn = new stockbyname.StockQuoteSoapClient(basicbinding, endpoint);
        XmlDocument xmlDocument = new XmlDocument();
        return sbn.GetQuoteAsync(SoapEnvelope);
    }
