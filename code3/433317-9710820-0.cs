    class SampleCode
    {
        class Team
        {
            private string _TeamName = "";
            private int _TeamProperty1 = 0;
            ObservableCollection<Territory> _Territories = new ObservableCollection<Territory>();
            public Team(string tName)
            {
                this.TeamName = tName;
            }
            public ObservableCollection<Territory> Territories
            {
                get { return _Territories; }
                set { _Territories = value; }
            }
            public string TeamName
            {
                get { return _TeamName; }
                set { _TeamName = value; }
            }
            public int TeamProperty1
            {
                get { return _TeamProperty1; }
                set { _TeamProperty1 = value; }
            }
        }
        class Territory
        {
            private string _TerritoryName = "";
            Team _AssociatedTeam = null;
            public Territory(string tName, Team team)
            {
                this.TerritoryName = tName;
                this.AssociatedTeam = team;
            }
            public Team AssociatedTeam
            {
                get { return _AssociatedTeam; }
                set { _AssociatedTeam = value; }
            }
            public string TerritoryName
            {
                get { return _TerritoryName; }
                set { _TerritoryName = value; }
            }
            public void Method1()
            {
                //Do Some Work
            }
        }
        class MyApplication
        {
            ObservableCollection<Team> _Teams = new ObservableCollection<Team>();
            ContextMenu _TeritorySwitcher = new ContextMenu();
            public MyApplication()
            {
                
            }
            public void AddTeam()
            {
                _Teams.Add(new Team("1"));
                _Teams.Add(new Team("2"));
                _Teams.Add(new Team("3"));
                _Teams.Add(new Team("4"));
                foreach (Team t in _Teams)
                {
                    t.Territories.Add(new Territory("1", t));
                    t.Territories.Add(new Territory("2", t));
                    t.Territories.Add(new Territory("3", t));
                }
                SetContextMenu();
            }
            private void SetContextMenu()
            {
                HierarchicalDataTemplate _hdtTerritories = new HierarchicalDataTemplate();
                _hdtTerritories.DataType = typeof(Territory);
                HierarchicalDataTemplate _hdtTeams = new HierarchicalDataTemplate();
                _hdtTeams.DataType = typeof(Team);
                FrameworkElementFactory _TeamFactory = new FrameworkElementFactory(typeof(TreeViewItem));
                _TeamFactory.Name = "txtTeamInfo";
                _TeamFactory.SetBinding(TreeViewItem.HeaderProperty, new Binding("TeamProperty1"));
                FrameworkElementFactory _TerritoryFactory = new FrameworkElementFactory(typeof(TreeViewItem));
                _TerritoryFactory.Name = "txtTerritoryInfo";
                _TerritoryFactory.SetBinding(TreeViewItem.HeaderProperty, new Binding("TerritoryProperty1"));
                
                _hdtTeams.ItemsSource = new Binding("Territories");
                _hdtTeams.VisualTree = _TeamFactory;
                _hdtTerritories.VisualTree = _TerritoryFactory;
                _hdtTeams.ItemTemplate = _hdtTerritories;
                _TeritorySwitcher.ItemTemplate = _hdtTeams;
                _TeritorySwitcher.ItemsSource = this._Teams;
            }
        }
    }
