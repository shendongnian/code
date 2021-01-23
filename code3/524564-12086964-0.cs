    private bool _inside;
    private void beforeSelect( object sender, EventArgs args )
    {
        if ( !_inside )
        {
            _inside = true;
            MessageBox.Show("Some msg");
            // more code
            _inside = false;
        }
    }
