    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsultaCNPJ
    {
        public class ConsultaCNPJBroker
        {
            private readonly CookieContainer _cookies = new CookieContainer();
            public String DominioReceitaFederal = "http://www.receita.fazenda.gov.br";
            public String GetDataReceitaFederal = "/pessoajuridica/cnpj/cnpjreva/cnpjreva_solicitacao2.asp";
            public String PostDataReceitaFederal = "/pessoajuridica/cnpj/cnpjreva/valida.asp";
            private String _viewState;
    
            public Bitmap GetCaptcha()
            {
                const string strViewState = "<input type=hidden id=viewstate name=viewstate value='";
                const string strImagemCaptcha = "<img border='0' id='imgcaptcha' alt='Imagem com os caracteres anti robô' src='";
                String htmlResult;
    
                using (var wc = new CookieAwareWebClient())
                {
                    wc.SetCookieContainer(_cookies);
                    wc.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; Synapse)";
                    wc.Headers[HttpRequestHeader.KeepAlive] = "300";
                    htmlResult = wc.DownloadString(DominioReceitaFederal + GetDataReceitaFederal);
                }
    
                if (htmlResult.Length > 0)
                {
                    _viewState = htmlResult;
    
                    int posString = _viewState.IndexOf(strViewState, StringComparison.Ordinal);
                    _viewState = _viewState.Substring(posString + strViewState.Length);
                    posString = _viewState.IndexOf("'>", StringComparison.Ordinal);
                    _viewState = _viewState.Substring(0, posString);
    
                    String urlImagemCaptcha = htmlResult;
                    posString = urlImagemCaptcha.IndexOf(strImagemCaptcha, StringComparison.Ordinal);
                    urlImagemCaptcha = urlImagemCaptcha.Substring(posString + strImagemCaptcha.Length);
                    posString = urlImagemCaptcha.IndexOf("'>", StringComparison.Ordinal);
                    urlImagemCaptcha = urlImagemCaptcha.Substring(0, posString);
                    urlImagemCaptcha = urlImagemCaptcha.Replace("amp;", "");
    
                    if (urlImagemCaptcha.Length > 0)
                    {
                        var wc2 = new CookieAwareWebClient();
                        wc2.SetCookieContainer(_cookies);
                        wc2.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; Synapse)";
                        wc2.Headers[HttpRequestHeader.KeepAlive] = "300";
                        byte[] data = wc2.DownloadData(DominioReceitaFederal + urlImagemCaptcha);
    
                        return new Bitmap(
                            new MemoryStream(data));
                    }
                    return null;
                }
                _viewState = "";
                return null;
            }
    
            public Stream Consulta(string aCNPJ, string aCaptcha, bool removerEspacosDuplos)
            {
                var request = (HttpWebRequest) WebRequest.Create(DominioReceitaFederal + PostDataReceitaFederal);
                request.ProtocolVersion = HttpVersion.Version10;
                request.CookieContainer = _cookies;
                request.Method = "POST";
    
                string fviewstate = _viewState;
                fviewstate = Uri.EscapeDataString((fviewstate));
    
                string postData = "";
                postData = postData + "origem=comprovante&";
                postData = postData + "viewstate=" + fviewstate + "&";
                postData = postData + "cnpj=" + new Regex(@"[^\d]").Replace(aCNPJ, string.Empty) + "&";
                postData = postData + "captcha=" + aCaptcha + "&";
                postData = postData + "captchaAudio=&";
                postData = postData + "submit1=Consultar&";
                postData = postData + "search_type=cnpj";
    
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
    
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
    
                WebResponse response = request.GetResponse();
                return response.GetResponseStream();                
            }
        }
    }
