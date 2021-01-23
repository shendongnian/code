    public static class UISearchBarExtensions
    {
        /// <summary>
        /// Finds the Cancelbutton
        /// </summary>
        /// <returns></returns>
        public static UIButton GetCancelButton(this UISearchBar searchBar)
        {
            //Look for a button, probably only one button, and that is probably the cancel button.
            return (UIButton)searchBar.GetAllSubViews().OfType<UIButton>().FirstOrDefault();
        }
        public static UIView FirstOrDefault(this IEnumerable<UIView> views)
        {
            return ((List<UIView>)views)[0];
        }
        public static IEnumerable<UIView> OfType<T>(this IEnumerable<UIView> views)
        {
            List<UIView> response = new List<UIView>();
            foreach(var view in views)
            {
                if(view.GetType() == typeof(T))
                {
                    response.Add(view);
                }
            }
            return response;
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
            searchBar.GetCancelButton().SetTitle(cancelTitle, UIControlState.Normal);
        }
    }
