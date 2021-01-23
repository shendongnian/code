    private void btnRandom_Click(object sender, EventArgs e)
    {
        String nFirstName;
        String nLastName;
        Random rnd= new Random();
        String[] randFirst = Separis_Fantasy_Tools_PE.Properties.Resources.fnames.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        nFirstName = randFirst[rnd.Next(randFirst.Length)];
        String[] randLast = Separis_Fantasy_Tools_PE.Properties.Resources.lnames.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        nLastName = randLast[rnd.Next(randLast.Length)];
        txtCharacterName.Text = nFirstName + " " + nLastName;
        return;
    }
