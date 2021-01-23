    /// <summary>
    /// Members that can be called from javascript. (or vbscript)
    /// </summary>
    public sealed class LINEARVIEWER_SL_SCRIPTS {
        [ScriptableMember]
        public void ChangeNetwork(string pNetworkFilterId, string pNetworkFilter) {
            MainViewModel MainVM = (MainViewModel)((MainPage)Application.Current.RootVisual).DataContext;
            long SectionID;
            if (long.TryParse(pNetworkFilterId, out SectionID) == false) {
                throw new FormatException("'" + pNetworkFilterId + "' not a valid section / network ID.");
            }
            MainVM.RoadFilterViewModel.SelectSectionAsync(SectionID, /* completed handler = */ null);
        }
    }
