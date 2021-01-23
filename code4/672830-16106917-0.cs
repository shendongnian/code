    private void Help_Click(object sender, RoutedEventArgs e)
    {
            // Checking the Condition
            if (Session["hasvalue"].ToString() == "Clicked") // Second click onwards current TAB itself
            {
                HtmlPage.Window.Navigate(new Uri("http://stackoverflow.com/"), "_self");
            }
            else // First Time it will be opened in New TAB
            {
                HtmlPage.Window.Navigate(new Uri("http://stackoverflow.com/"), "_blank");
            }
    
            // Assign this value to session
            Session["hasvalue"] = "Clicked";
    }
