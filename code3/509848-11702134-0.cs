        public override string Text
        {
            get
            {
                if (base.Text.Contains(" ريال"))
                {
                    return base.Text.Replace(" ريال", "");
                }
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
