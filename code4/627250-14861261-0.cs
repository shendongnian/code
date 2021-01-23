    protected override void OnPreRender(EventArgs e)
        {
            if (!string.IsNullOrEmpty(_errorText))
            {
                this.Zone.ErrorText += "I'm an error<br/>Fix me damnit!";                
            }
            base.OnPreRender(e);
        }
