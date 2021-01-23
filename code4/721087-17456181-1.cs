    protected override void Dispose(bool disposing)
    {
        if (/* you need to close a child form */)
        {
            // close the child form, maybe by calling its Dispose method
        }
        else
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
