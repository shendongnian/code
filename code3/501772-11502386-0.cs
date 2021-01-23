    Form f = new MessageForm();
    f.Show(this);         //Make sure we're the owner
    this.Enabled = false; //Disable ourselves
    //Do processing here
    this.Enabled = true;  //We're done, enable ourselves
    f.Close();            //Dispose message form
