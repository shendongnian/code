     url = objHttpWebResponse.Headers["Location"].ToString();
                            MessageBox.Show("Redirect To " + objHttpWebResponse.Headers["Location"]);
                            System.Threading.Thread.Sleep(2000);
                            Uri final = new Uri(new Uri(txtURL.Text), url);
                            string finalurl = final.AbsoluteUri;
                            download(finalurl);
