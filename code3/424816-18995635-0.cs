        private void ToggleToolBarButtons(string button)
        {
            foreach (Object o in this.stkToolBar.Children)
            {
                if (o.GetType() == typeof(ToggleButton))
                {
                    ToggleButton t = o as ToggleButton;
                    if (t.Name != button)
                        t.IsChecked = false;
                    else
                        t.IsChecked = true;
                }
            }
        }
