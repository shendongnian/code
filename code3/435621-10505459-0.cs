    private void listBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var nPhone = listBox4.SelectedItem as PhoneList;
      if (nPhone == null)
      {
        return;
      }
      
      string mPhoneCopy = nPhone.Telnum;
      string mNameCopy = nPhone.Epon;
      
      var pt = new PhoneCallTask();
      pt.DisplayName = mNameCopy;
      pt.PhoneNumber = mPhoneCopy;
      pt.Show();
    }
