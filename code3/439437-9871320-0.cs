    public static class GlobalClass
    {
        public string PropertyName
        {
            get;
            set;
        }
    }
    private void txtText_TextChanged(object sender, EventArgs e)
    {
        GlobalClass.PropertyName=txtText.Text
    }
