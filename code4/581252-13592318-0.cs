    public bool info(string channel)
    {
       object o = Properties.Resources.ResourceManager.GetObject(channel);
       if (o is Image)
       {
           channelPic.Image = o as Image;
           return true;
       }
       return false;
    }
