     private void LoadMemoryFromScreen()
        {    
         Dictionary<string, string> driver = new Dictionary<string, string>();
         driver.Add("position", position.Text);
         driver.Add("othervalue",value.Text); ///etc..
         Session["dict"] = driver;
        }
