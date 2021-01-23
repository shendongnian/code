    private void CreateAButton()
        {
            var button = new ImageButton();
            button.ImageUrl = "yourimage.png";
            button.ID = "Button1";           
            button.PostBackUrl = "http://www.towi.lt";
            Page.Form.Controls.Add(button);
        }
