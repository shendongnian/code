    private void Likebtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        Image img = sender as Image;
        if (img == null) return;
        switch (img.Source.ToString())
        {
           case "The like button's location":
               //change do your like logic, and then change it to an unlike button
               break;
           //the opposite for the unlike button's location
        }
    }
