    //where ever you create a new Basic, add to the event handler
    Basic Basic = new Basic();
    Basic.HPChanged += Basic_HPChanged;
    private void Basic_HPChanged(object sender, EventArgs e)
    {
        Basic b_sender = (Basic)sender;
        int NewHealth = b_sender.HP;
        //Update whatever value needs to be updated, here
    }
