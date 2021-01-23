             HtmlGenericControl script1 = new HtmlGenericControl("script");
            script1.Attributes.Add("type", "text/javascript");
            script1.Attributes.Add("src", "http://books.google.com/books/previewlib.js");
            this.Page.Header.Controls.Add(script1);
            string GoogleScript = "";
            
            string isbncode = "";
            if (Page.Request.QueryString["isbn"] != null)
                isbncode = Page.Request.QueryString["isbn"];
            
            GoogleScript = "GBS_setLanguage('en'); GBS_insertPreviewButtonPopup('ISBN:";
            isbncode = isbncode + "');";
            HtmlGenericControl script3 = new HtmlGenericControl("script");
            script3.Attributes.Add("type", "text/javascript");
            script3.InnerHtml = GoogleScript + isbncode ;
            this.Page.Controls.Add(script3);
