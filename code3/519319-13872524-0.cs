    protected void myListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
     if (e.CommandName == "Select")
      {
      ModalPopupExtender popUp = (ModalPopupExtender)lvAlbum.FindControl("PopUpDialog");
      popUp.Show();
      }
    }
