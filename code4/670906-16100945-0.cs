    public void liveJob_Status(object sender, EncodeStatusEventArgs e)
        {
            if (e.Status == EncodeStatus.Jumped)
            { LiveFileSource file = (LiveFileSource)e.LiveSource; 
              string name = file.Name;
              string modified_name = "Encode" + name;
              File.Move(DataDirectory + @"\" + name, DataDirectory + @"\" + name.Replace(name, modified_name)); 
            }
        }
