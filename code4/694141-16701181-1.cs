    private void enter_Click(object sender, EventArgs e)
    {
        using (FileStream file2 = new FileStream(FileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
        {
            using (StreamWriter write = new StreamWriter(file2))
            {
                try
                {
                    friend.FirstName = firstName.Text;
                    friend.LastName = lastName.Text;
                    friend.PhoneNumber = phoneNumber.Text;
                    friend.Month = Convert.ToInt32(birthMonth.Text);
                    friend.Day = Convert.ToInt32(birthday.Text);
                    write.WriteLine(friend.ToString());
                    MessageBox.Show("Wrote " + friend.ToString() + " to file.");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + " Please reenter the information.");
                }
                firstName.Clear();
                lastName.Clear();
                phoneNumber.Clear();
                birthMonth.Clear();
                birthday.Clear();
            }
        }
    }
