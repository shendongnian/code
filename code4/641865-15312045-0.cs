               lblplayName[i].DoubleClick += (senders, es) =>
               {
                  
                   LinkLabel label = (LinkLabel)senders;
                   string PlayListFile = label.Text;
                   try
                   {
                       WMPLib.IWMPPlaylist list = axWindowsMediaPlayer1.playlistCollection.getByName(PlayListFile).Item(0);
                       axWindowsMediaPlayer1.currentPlaylist = list;
                   }
                   catch
                   {
                         //exception handling code
                   }
               };
