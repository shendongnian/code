    public static class NimbleSearchBarExtensions
    {
        /// <summary>
        /// Finds the Cancelbutton
        /// </summary>
        /// <returns></returns>
        public static UIButton GetCancelButton(this UISearchBar searchBar)
        {
            //Look for a button, probably only one button, and that is probably the cancel button.
            IEnumerable<UIView> allSubViews = GetAllSubViews(searchBar);
            return allSubViews.OfType<UIButton>().FirstOrDefault();
        }
        /// <summary>
        /// Recursively traverses all subviews and returns them in a little list.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static IEnumerable<UIView> GetAllSubViews(this UIView view)
        {
            List<UIView> retList = new List<UIView>();
            retList.AddRange(view.Subviews);
            foreach (var subview in view.Subviews)
            {
                retList.AddRange(subview.GetAllSubViews());
            }
            return retList;
        }
        /// <summary>
        /// Sets the title of the search bars cancel button
        /// </summary>
        /// <param name="searchBar"></param>
        /// <param name="cancelTitle"></param>
        public static void SetCancelTitle(this UISearchBar searchBar, string cancelTitle)
        {
            searchBar.GetCancelButton().SetTitle(cancelTitle,UIControlState.Normal);
        }
    }
