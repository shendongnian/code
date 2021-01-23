            private void newbrowser()
        {
            Awesomium.Windows.Forms.WebControl browser =
                                        new Awesomium.Windows.Forms.WebControl();
                browser = new Awesomium.Windows.Forms.WebControl();
                browser.Paint += browser_Paint;
                browser.Location = new System.Drawing.Point(1, 1);
                browser.Name = "webControl";
                browser.Size = new System.Drawing.Size(1024, 768);
                browser.Source = new System.Uri("http://checkip.dyndns.com/", System.UriKind.Absolute);
                browser.TabIndex = 0;
        }
