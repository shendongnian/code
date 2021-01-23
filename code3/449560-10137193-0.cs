    public class ScrollIntoViewForListView : Behavior<ListView>
    {
        /// <summary>
        ///  When Beahvior is attached
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }
        /// <summary>
        /// On Selection Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AssociatedObject_SelectionChanged(object sender,
                                               SelectionChangedEventArgs e)
        {
            if (sender is ListView)
            {
                ListView listview = (sender as ListView);
                if (listview.SelectedItem != null)
                {
                    listview.Dispatcher.BeginInvoke(
                        (Action) (() =>
                                      {
                                          listview.UpdateLayout();
                                          if (listview.SelectedItem !=
                                              null)
                                              listview.ScrollIntoView(
                                                  listview.SelectedItem);
                                      }));
                }
            }
        }
        /// <summary>
        /// When behavior is detached
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.SelectionChanged -=
                AssociatedObject_SelectionChanged;
        }
    }
  
