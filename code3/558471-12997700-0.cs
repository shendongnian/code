    private System.Threading.Timer timer;
    public YourClass()
    {
        timer = new System.Threading.Timer(UpdateProperty, null, 1000, 1000);
    }
    private void UpdateProperty(object state)
    {
        lock(this)
        {
            // Update property here.
        }
    }
