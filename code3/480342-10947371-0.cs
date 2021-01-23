    public static void FireOnMouseDown(object sender, MouseEventArgs e)
        {
            if (OnMouseDown != null)
                OnMouseDown(this, e, sender as Control);
        }
