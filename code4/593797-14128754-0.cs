    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:Mage_Api_Model_Server_V2_HandlerAction", RequestNamespace="urn:Magento", ResponseNamespace="urn:Magento")]
    [return: System.Xml.Serialization.SoapElementAttribute("result")]
    public salesOrderInvoiceEntity salesOrderInvoiceInfo(string sessionId, string invoiceIncrementId) {
        try
        {
            object[] results = this.Invoke("salesOrderInvoiceInfo", new object[] {
                        sessionId,
                        invoiceIncrementId}); // exception thrown here
        }
        catch(Exception) {}
        if(results != null && results.Count() > 0) return ((salesOrderInvoiceEntity)(results[0]));
        throw new Exception("results is null");
    }
