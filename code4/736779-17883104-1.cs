    public static string GenerateCaptcha( this HtmlHelper helper )  
    {           
        var captchaControl = new Recaptcha.RecaptchaControl  
                {  
                        ID = "recaptcha",  
                        Theme = "blackglass",  
                    PublicKey = -- Put Public Key Here --,  
                            PrivateKey = -- Put Private Key Here --  
                };  
      
        var htmlWriter = new HtmlTextWriter( new StringWriter() );  
        captchaControl.RenderControl(htmlWriter);  
        return htmlWriter.InnerWriter.ToString();  
    }  
