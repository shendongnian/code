    private void onServerInfo(msgBox message)
    {
        try 
        {
          serverInfo.info info = (serverInfo.info)message.getMessage("info");
          MessageBox.Show(info.name + " ; " + info.type + " ; " + info.limit); // works with everything showing up right
          ServerName.Text = info.name; //this is a string
          ServerType.Text = info.type.ToString(); // this is a enum
          MaxLimit.Text = info.limit.ToString(); // this is a int
          MessageBox.Show(ServerName.Text + " ; " + ServerType.Text + " ; " + MaxLimit.Text); // doesnt ever show
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
    }
