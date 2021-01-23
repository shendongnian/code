    public static bool IsObjectEmpty(Control ctrlThis)
    {
        Type t = ctrlThis.GetType();
        switch (t)
        {
            case typeof(TextBox):
                TextBox txtThis = (TextBox)ctrlThis;
                if (txtThis.Text == "" || txtThis.Text == null)
                { return false; }
                break;
        }
    }
