    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Windows.Forms;
    
    namespace LeituraWeb
    {
        public partial class Form1 : Form
        {
    
            String viewState;
            public String Dominio_ReceitaFederal = "http://www.receita.fazenda.gov.br/";
            public String GetData_ReceitaFederal = "pessoajuridica/cnpj/cnpjreva/cnpjreva_solicitacao2.asp";
            public String PostData_ReceitaFederal = "pessoajuridica/cnpj/cnpjreva/valida.asp";
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btnGo_Click(object sender, EventArgs e)
            {
    
                int PosString;
                String StrViewState = "<input type=hidden id=viewstate name=viewstate value='";
                String StrImagemCaptcha = "<img border='0' id='imgcaptcha' alt='Imagem com os caracteres anti robô' src='";
                String UrlImagemCaptcha = "";
                String HtmlResult = "";
    
                using (WebClient wc = new WebClient()){
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.DownloadString(Dominio_ReceitaFederal + GetData_ReceitaFederal);
                }
    
                if (HtmlResult.Length > 0)
                {
                    viewState = HtmlResult;
    
                    // executando um crop do viewstate para utilizar no post
                    PosString = viewState.IndexOf(StrViewState);
                    viewState = viewState.Substring(PosString + StrViewState.Length);
                    PosString = viewState.IndexOf("'>");
                    viewState = viewState.Substring(0, PosString);
    
                    //executando um crop na url da imagem 
                    UrlImagemCaptcha = HtmlResult;
                    PosString = UrlImagemCaptcha.IndexOf(StrImagemCaptcha);
                    UrlImagemCaptcha = UrlImagemCaptcha.Substring(PosString + StrImagemCaptcha.Length);
                    PosString = UrlImagemCaptcha.IndexOf("'>");
                    UrlImagemCaptcha = UrlImagemCaptcha.Substring(0, PosString);
                    UrlImagemCaptcha = UrlImagemCaptcha.Replace("amp;", "");                
    
                    // populando a imagem do captcha dentro de um picturebox
                    if (UrlImagemCaptcha.Length > 0)
                        pictureBox1.Image = new System.Drawing.Bitmap(new System.IO.MemoryStream(new System.Net.WebClient().DownloadData(Dominio_ReceitaFederal + UrlImagemCaptcha)));
                }
                else
                {
                    viewState = "";
                }
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                WebRequest request = WebRequest.Create(Dominio_ReceitaFederal + PostData_ReceitaFederal);
    
                // Formatando o ViewState Recebido
                string fviewstate = viewState;
                fviewstate = System.Uri.EscapeDataString(System.Uri.UnescapeDataString(fviewstate));
    
                // inserindo os campos a serem postados
                string postData = "";
                postData = postData + "origem=comprovante&";
                postData = postData + "viewstate=" + fviewstate + "&";
                postData = postData + "cnpj=00000000000000&";
                postData = postData + "captcha=000000&";
                postData = postData + "captchaAudio=&";
                postData = postData + "submit1=Consultar&";
                postData = postData + "search_type=cnpj";
    
                // montando a requisicao
    
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);           
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
    
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
    
                WebResponse response = request.GetResponse();           
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
    
                // ---------- erro aqui !!!
                // retorno da sefaz ---- sempre retorna -- Parametros Inválidos
                Console.WriteLine(responseFromServer);
    
                reader.Close();
                dataStream.Close();
                response.Close();
            }
    
        }
    }
