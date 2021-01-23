    foreach (Control ctrl in this.Controls)
    {
        if (ctrl is ContentPlaceHolder)
        {
            ContentPlaceHolder cph = (ContentPlaceHolder)ctrl;
            if (cph.ID == "placeHolder1")
            {
                // do whatever
            }
        }
    }
