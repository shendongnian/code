         protected void btnRender_Click(object sender, EventArgs e)
            {
                if(CheckUrlExists(urltxt.Text)
                {
                    string strResult = string.Empty;
                    WebResponse objResponse;
                    WebRequest objRequest = System.Net.HttpWebRequest.Create(urltxt.Text);
                    objResponse = objRequest.GetResponse();
                    using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                    {
                        strResult = sr.ReadToEnd();
                        sr.Close();
                    }
                    strResult = strResult.Replace("<form id='form1' method='post' action=''>", "");
                    strResult = strResult.Replace("</form>", "");
                    TextBox1.Text = strResult.Trim();
                    div.InnerHtml = strResult.Trim();
                }
                else
                {
                    Console.WriteLine("Not a Valid URL");
                }
            }
