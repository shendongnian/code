    /// <summary>
    /// Creates the taskbar icon. This message is invoked during initialization,
    /// if the taskbar is restarted, and whenever the icon is displayed.
    /// </summary>
    private void CreateTaskbarIcon()
    {
      lock (this)
      {
        if (!IsTaskbarIconCreated)
        {
          const IconDataMembers members = IconDataMembers.Message
                                          | IconDataMembers.Icon
                                          | IconDataMembers.Tip;
          //write initial configuration
          var status = Util.WriteIconData(ref iconData, NotifyCommand.Add, members);
          if (!status)
          {
            throw new Win32Exception("Could not create icon data");
          }
          //set to most recent version
          SetVersion();
          messageSink.Version = (NotifyIconVersion) iconData.VersionOrTimeout;
          IsTaskbarIconCreated = true;
        }
      }
    }
