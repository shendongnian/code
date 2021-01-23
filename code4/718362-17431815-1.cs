    using System;
    using System.Collections.ObjectModel;
    namespace So17371439ItemsLayoutBounty
    {
        public partial class MainWindow
        {
            public ObservableCollection<PreferenceGroup> PreferenceGroups { get; private set; }
            public MainWindow ()
            {
                var rnd = new Random();
                PreferenceGroups = new ObservableCollection<PreferenceGroup>();
                for (int i = 0; i < 100000; i++) {
                    var group = new PreferenceGroup { Name = string.Format("Group {0}", i), SelectionMode = rnd.Next(1, 4) };
                    int nprefs = rnd.Next(5, 40);
                    for (int j = 0; j < nprefs; j++)
                        group.Preferences.Add(new Preference { Name = string.Format("Pref {0}", j), Quantity = rnd.Next(100) });
                    PreferenceGroups.Add(group);
                }
                InitializeComponent();
            }
        }
        public class PreferenceGroup
        {
            public string Name { get; set; }
            public int SelectionMode { get; set; }
            public ObservableCollection<Preference> Preferences { get; private set; }
            public PreferenceGroup ()
            {
                Preferences = new ObservableCollection<Preference>();
            }
        }
        public class Preference
        {
            public string Name { get; set; }
            public string GroupId { get; set; }
            public int Quantity { get; set; }
        }
    }
