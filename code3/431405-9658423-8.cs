    void Init() {
       //mapping between event and tabpage-instance
       _mapping = new Dictionary<TabPage, Func>();
       _mapping.Add(tabPage1, OnHandleTab1);
       _mapping.Add(tabPage2, OnHandleTab2);
       tabControl1.TabIndexChanged += HandleTabIndexChanged;
    }
    void OnHandleTab1() {
        if (HandleTab1 != null)
            HandleTab1();
    }
     void OnHandleTab2() {
        if (HandleTab2 != null)
            HandleTab2();
    }
    void HandleTabIndexChanged(object sender, EventArgs args) {
        var tabControl = sender as TabControl;
        //use SelectedTab as key
        var func = _mapping[tabControl.SelectedTab];
        func();
    }
