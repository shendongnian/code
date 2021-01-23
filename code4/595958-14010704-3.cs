    HtmlDocument d = new HtmlDocument();
                                try
                                {
                                    d = this.Download(prp.PropertyUrl);
                                }
                                catch (WebException e)
                                {
                                    this.Msg(Site.ErrorSeverity.Severe, "Error connecting to " + this.URL + " : Resubmitting..");
                                    wc = new CookieWebClient();
                                    d = this.Download(prp.PropertyUrl);
                                }
