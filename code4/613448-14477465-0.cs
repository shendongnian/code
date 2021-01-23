        private void txtBoxCatchScanner_TextChanged(object sender, EventArgs e)
    {             
    Member member = new Member();
    member.FirstName = "";
    member.LastName = "";            
    
    if(txtBoxCatchScanner.Text == "" | txtBoxCatchScanner.Text == string.Empty)
    return;    // Leave function if the box is empty
    //Get BarCode
    //VALIDATE: Is a Number           
    int numTest = 0;
    if (int.TryParse(txtBoxCatchScanner.Text, out numTest))
    {
        //IS A NUMBER
        //member.MemberID = Convert.ToInt32(txtBoxCatchScanner.Text);
        member.MemberID = numTest; // you already converted to a number...
        //SEARCH
        //Search Member by MemberID (barcode)
        List<Member> searchMembers = Search.SearchForMember(member);
        if (searchMembers.Count == 0)
        {
            lblAlert.Text = "No Member Found";
        }
        else
        {
            foreach (Member mem in searchMembers)
            {
                lblMemberStatus.Text = mem.MemberStatus;
                lblMemberName.Text = mem.FirstName + " " + mem.LastName;
                lblMemberID.Text = mem.MemberID.ToString();
                lblMessages.Text = mem.Notes;
                if (mem.MemberStatus == "OVERDUE") // OR .. OR .. OR ...
                {
                    lblAlert.Visible = true;
                    lblAlert.Text = "!! OVERDUE !!";
                    //PLAY SIREN aLERT SOUND
                    //C:\\WORKTEMP\\siren.wav
                    SoundPlayer simpleSound = 
                        new SoundPlayer(@"C:\\WORKTEMP\\siren.wav");
                    simpleSound.Play();
                }
                else
                {
                    lblAlert.Visible = true;
                    lblAlert.Text = mem.MemberStatus;
                }
            }
        }
    }
    else
    {
        //IS NOT A NUMBER
        lblAlert.Text = "INVALID - NOT A NUMBER";                
        ////
        //lblMemberName.Text = "";
        //lblMemberID.Text = "";
        //lblMemberID.Text = "";
    }
    txtBoxCatchScanner.Clear();
    }
