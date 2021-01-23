    public class YourWebPart : WebPart
    {
        protected override void CreateChildControls()
        {
            Button YourButton = new Button();
            YourButton.Text = "Click me !";
            YourButton.OnClientClick = "alert('Cool stuff');";
            this.Controls.Add(YourButton);
        }
    }
