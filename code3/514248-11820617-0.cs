    private void OnBrowserClick(object sender, EventArgs e)
    {
        var ge = e as GeckoDomEventArgs;
        if (ge.Target.ClassName =="choose_image")
        {
           //Handle the click...
		
