    private void btnCheckMember_Click(object sender, EventArgs e)
    {             
        Member member = new Member();
        member.FirstName = "";
        member.LastName = "";            
        string memberText = txtBoxCatchScanner.Text.Trim();
        txtBoxCatchScanner.Text = String.Empty;
        int numTest = 0;
        if (String.IsNullOrEmpty(memberText) ||!Int32.TryParse(memberText, out numTest))
        {
            //IS NOT A NUMBER
            lblAlert.Text = "INVALID - NOT A NUMBER";                
            return;
        }
        member.MemberID = numTest;
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
                SoundPlayer simpleSound = new SoundPlayer(@"C:\\WORKTEMP\\siren.wav");
                simpleSound.Play();
            }
            else
            {
                lblAlert.Visible = true;
                lblAlert.Text = mem.MemberStatus;
            }
        }
    }
