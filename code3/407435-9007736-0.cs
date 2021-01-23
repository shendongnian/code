    for (int j = 1; j < 4; j++)
            {
                string ph = "placeHolder" + j;
    
                ContentPlaceHolder cph = this.Master.FindControl("MainContent") as ContentPlaceHolder;
                Control ctrlPh = cph.FindControl(ph);
    
                StringWriter sw = new StringWriter();
                HtmlTextWriter w = new HtmlTextWriter(sw);
                ctrlPh.RenderControl(w);
                divHtml = divHtml + sw.GetStringBuilder().ToString();
                
            }
