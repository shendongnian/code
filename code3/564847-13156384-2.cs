     public void DoSomethingWhenChildRaisesYourEvent(List<string> lstParam)
        {
            foreach (string  item in lstParam)
            {
                // Just show the strings on the screen
                lblResult.Text = lblResult.Text + " " + item;
            }
        }
