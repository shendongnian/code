    public override string Text
            {
                get
                {
                    string text = base.Text;
                    if (text.Contains(" ريال"))
                    {
                        return text.Replace(" ريال", "");
                    }
                    return base.Text;
                }
                set
                {
                    base.Text = value;
                }
            }
