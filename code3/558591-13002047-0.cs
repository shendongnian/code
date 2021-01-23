    Dictionary<Keys, DateTime> keytimes = new Dictionary<Keys, DateTime>();
    
    public bool IsKeyDownWithDelayPassed(Keys key, long delay)
    {
        if(!keytimes.Keys.Contains(key) || keytimes[key] == DateTime.MinValue)
            return false;
        long elapsed = DateTime.Now.Ticks - keytimes[key].Ticks;
        if (delay < elapsed)
        {
            return true;
        }
    
        return false;
    }
    
    private void KeyDownEvent(object sender, KeyEventArgs e)
    {
        keytimes[e.KeyData] = DateTime.Now;
    }
    
    private void KeyUpEvent(object sender, KeyEventArgs e)
    {
        keytimes[e.KeyData] = DateTime.MinValue;
    }
