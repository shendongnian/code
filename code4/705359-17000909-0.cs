    private void myWB1_ScriptNotify(object sender, NotifyEventArgs e)
    {
        string passingURL = e.Value.ToString();
        passingURL = Uri.EscapeUriString(passingURL);
        if (!String.IsNullOrEmpty(passingURL)) 
        {
           App.goToPage("/PictureViewPage.xaml?pictureurl=" + passingURL);
        }
    }
