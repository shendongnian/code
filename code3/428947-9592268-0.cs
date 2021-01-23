    private int? _checked
    public int? Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                if (value == "")
                    _checked = null;
                else if (value.ToLower() == "true")
                    _checked = true;
                else
                    _checked = false;
            }
        }
