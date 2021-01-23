    event EventHandler HandleTab1;   
    void Init() {
       tabControl1.TabIndexChanged += HandleTabIndexChanged;
    }
    
    void HandleTabIndexChanged(object sender, EventArgs args) {
       var tabControl = sender as TabControl;
       //the following could be a mapping of tab-instance an handle-delegate
       if (tabControl.SelectedTab == tab1)
          // this could be a event...
          HandleTab1()
       else if (tabControl.SelectedTab == tab2)
          HandleTab2()
    }
