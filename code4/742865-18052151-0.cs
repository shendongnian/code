      set Session = CreateObject("Redemption.RDOSession")
      Session.MAPIOBJECT = Application.Session.MAPIOBJECT
      set Inbox = Session.GetDefaultFolder(olFolderInbox)
      set Msg = Inbox.Items.Add("IPM.Note")
      Mg.Sent = true
      Msg.Import "C:\Temp\test", 1024 'olRfc822
      Msg.Save
 
