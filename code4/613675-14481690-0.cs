    while(button1.Text == "")
    {
        if (storeRI == 1)
        {
            if (button1.Text == "")
            {
                button1.Text = "X";
            }
            else
            {
                 //Need to generate another random number
                 storeRI = rc.Next(1, 9);
            }
        }
        else if (storeRI == 2)
        {
         ...
        }
        else
            break;
    }
