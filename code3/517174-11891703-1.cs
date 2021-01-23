    public string EnviarMensaje(int intIdVendedor, 
                                string strCorreoPara, 
                                string strCorreosAdicionales, 
                                string strTema, 
                                string strMensaje, 
                                Stream attachmentData)
    {
    
    ...
    
      var attachment = new Attachment(attachmentData, "nameOfAttachment");
    
    ...
     
    }
