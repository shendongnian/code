	public event EventHandler Getting;
	public event EventHandler Setting;
	void get()
    {
        if (Getting  != null)
			Getting.Invoke(this, EventArgs.Empty);
    }
    void post()
    {
        if (Setting  != null)
			Setting.Invoke(this, EventArgs.Empty);
    }
