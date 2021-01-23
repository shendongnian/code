    private void next_TabPage(TabPage tabpage1, TabPage tabpage2)
        {
            TabControl.SelectedTab = tabpage2;
            tabpage2.BindingContextChanged += (_, __) =>
            TabControl.SelectedTab = tabpage1;
        }
