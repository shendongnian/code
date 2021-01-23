    public new event EventHandler Click {
        Add {
            base.Click += value;
            foreach(Control i in Controls) {
                i.Click+=value;
            }
        }
        remove {
            base.Click -= value;
            foreach(Control i in Controls) {
                i.Click -= value;
            }
        }
        }
