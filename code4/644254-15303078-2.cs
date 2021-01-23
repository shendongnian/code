        private void Timer1_Tick(sender, args) 
        {
            Application.DoEvents();
    
    // make sure your are pulling right element id
            HtmlElement cTag = webBrowser.Document.GetElementById("myelement");         
            
            if(cTag != null) // if elemnt is found than its fine. 
            { 
                cTag.SetAttribute("value", "Eugene");
                Timer1.Enabled = false;
            } 
            else 
            {
    // dont worry, the ajax request is still in progress... just wait on it and move on for the next tick. 
            }
            Application.DoEvents(); // you can call it at the end too.
        }
