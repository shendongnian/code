    for (int i=0; i <12; i++) {
        button = new UIButton(new RectangleF(xBase + i * 25,100 + i,25,25));
        button.SetBackgroundImage(UIImage.FromBundle ("Images/b.png"),UIControlState.Normal);
        button.TouchUpInside += (s, e) => { 
            var j = i;
            UIAlertView alert = new UIAlertView("",j.ToString(),null,"",null);
            alert.Show();
        };
    this.Add (button);
