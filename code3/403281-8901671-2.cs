    private int state = 0;
    public SMSHandler()
    {
        ie = new InternetExplorer();
        ie.DocumentComplete += ie_DocumentComplete;
        ie.Visible = true;
    }
    void ie_DocumentComplete(object pDisp, ref object URL) {
        object Empty = 0;
        if (state == 1) {
            ie.Navigate2(ref URL2, ref Empty, ref Empty, ref Empty, ref Empty);
            state++;
        }
        else if (state == 2) {
            IHTMLDocument2 HTMLDoc = (IHTMLDocument2)ie.Document;
            // etc..
            state = 0;
        }
    }
    public void openMACS()
    {
        object Empty = 0;
        state = 1;
        ie.Navigate2(ref URL, ref Empty, ref Empty, ref Empty, ref Empty);
    }
