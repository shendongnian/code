    webBrowser1.Invoke(new ThreadStart(delegate
                        {
                            Application.DoEvents();
                            HtmlElement token2 = webBrowser1.Document.All["token2"];
                            //MessageBox.Show(token2.InnerHtml);
                            token2.InnerHtml = currentToken;
                        }));
