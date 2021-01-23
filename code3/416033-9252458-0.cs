    FillFrame(webBrowser1.Document.Window.Frames);
 
    private void FillFrame(HtmlWindowCollection hwc)
            {
               
    
                if (hwc == null) return;
                foreach (HtmlWindow hw in hwc)
                {
                    HtmlElement getSpanid = hw.Document.GetElementById("mDisplayCiteList_ctl00_mResultCountLabel");
                    if (getSpanid != null)
                    {
                       
                        doccount = getSpanid.InnerText.Replace("Documents", "").Replace("Document", "").Trim();
    
                        break;
                    }
                  
                    if (hw.Frames.Count > 0) FillFrame(hw.Frames);
                }
    
                
            }
