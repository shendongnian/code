        int numWO = 0;
        var ControlLibrary = new Dictionary<string, Control>();
        public void addListView()
        {
            ListView newListView = new ListView();
            newListView.AllowDrop = true;
            newListView.DragDrop += listView_DragDrop;
            newListView.DragEnter += listView_DragEnter;
            newListView.MouseDoubleClick += listView_MouseDoubleClick;
            newListView.MouseDown += listView_MouseDown;
            newListView.DragOver += listView_DragOver;
            newListView.Width = 200;
            newListView.Height = 200;
            newListView.View = View.Tile;
            newListView.MultiSelect = false;
            flowPanel.Controls.Add(newListView);
            numWO++;
            ControlLibrary.Add( "UniqueName"+ numWO.ToString(), newListView);
        }
        public void referenceItem(int ID)
        {
            return ControlLibrary["UniqueName" + ID.ToString()];
        }
        public void Main()
        {
            addListView();
            ((ListView)referenceItem(0)).Name = "test";
        }
