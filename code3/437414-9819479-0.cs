        private void setListEnabled(bool enabled) {
            listEnabled = enabled;
            if (listEnabled) checkedListBox1.BackColor = Color.FromKnownColor(KnownColor.Window);
            else checkedListBox1.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
