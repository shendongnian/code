    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var myButton = this.GetTemplateChild("myButton") as Button;
        if(myButton != null)
        {
            myButton.Click += ...;
    }
