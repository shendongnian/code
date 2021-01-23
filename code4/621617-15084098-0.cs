    private void label1_Click(object sender, EventArgs e)
    {
      // mainform.BringToFront(); // doesn't work
      BeginInvoke(new VoidHandler(OtherFormToFront));
    }
    delegate void VoidHandler();
    private void OtherFormToFront()
    {
      mainform.BringToFront(); // works
    }
