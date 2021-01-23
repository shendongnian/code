    // Based on
    // http://www.codeproject.com/Articles/165370/Creating-View-Switching-Applications-with-Prism-4#AppendixA
    // with my modifications.
    /// <summary>
    /// Enables use of a Ribbon control as a Prism region.
    /// </summary>
    /// <remarks> See Developer's Guide to Microsoft Prism (Ver. 4), p. 189.</remarks>
    [Export]
    public class RibbonRegionAdapter : RegionAdapterBase<Ribbon> {
        private static readonly Hashtable RibbonTabs = new Hashtable();
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="behaviorFactory">Allows the registration
        /// of the default set of RegionBehaviors.</param>
        [ImportingConstructor] 
        public RibbonRegionAdapter(IRegionBehaviorFactory behaviorFactory)
            : base(behaviorFactory) {}
        /// <summary>
        /// Adapts a WPF control to serve as a Prism IRegion. 
        /// </summary>
        /// <param name="region">The new region being used.</param>
        /// <param name="regionTarget">The WPF control to adapt.</param>
        protected override void Adapt(IRegion region, Ribbon regionTarget) {
            region.Views.CollectionChanged += (sender, e) => {
                switch (e.Action) {
                    case NotifyCollectionChangedAction.Add:
                        foreach (FrameworkElement element in e.NewItems) {
                            if (element is Ribbon) {
                                Ribbon rb = element as Ribbon;
                                var tabList = new List<RibbonTab>();
                                var items = rb.Items;
                                for (int i = rb.Items.Count - 1; i >= 0; i--) {
                                    if (!(rb.Items[i] is RibbonTab)) continue;
                                    RibbonTab rt = (rb.Items[i] as RibbonTab);
                                    rb.Items.Remove(rt); // remove from existing view ribbon
                                    regionTarget.Items.Add(rt); // add to target region ribbon
                                    tabList.Add(rt); // add to tracking list
                                    
                                    // Without these next 3 lines the tabs datacontext would end up being inherited from the Ribbon to which 
                                    // it has been transferred.
                                    // Not sure if this is the best place to do this but it works for my purposes at the moment
                                    if (rt.DataContext.Equals(regionTarget.DataContext)) { // then it is inherited
                                        rt.DataContext = rb.DataContext; // so set it explicitly to the original parent ribbons datacontext
                                    }
                                }
                                // store tracking list in hashtable using string key (= the view type name)
                                var key = rb.GetType().Name;
                                RibbonTabs[key] = tabList;
                            } else if (element is RibbonTab) {
                                // the datacontext should already be set in  these circumstances
                                regionTarget.Items.Add(element);
                            }
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (UIElement elementLoopVariable in e.OldItems) {
                            var element = elementLoopVariable;
                            if (element is Ribbon) {
                                Ribbon rb = element as Ribbon;
                                var key = rb.GetType().Name;
                                if (!RibbonTabs.ContainsKey(key)) continue; // no ribbon tabs have been tracked
                                var tabList = (RibbonTabs[key] as List<RibbonTab>) ?? new List<RibbonTab>();
                                foreach (RibbonTab rt in tabList)
                                {
                                    if (!regionTarget.Items.Contains(rt)) continue; // this shouldn't happen
                                    regionTarget.Items.Remove(rt); // remove from  target region ribbon
                                    rb.Items.Add(rt); // restore to view ribbon
                                }
                                RibbonTabs.Remove(key); // finished tracking so remove from hashtable
                            } else if (regionTarget.Items.Contains(element)) {
                                regionTarget.Items.Remove(element);
                            }
                        }
                        break;
                }
            };
        }
        protected override IRegion CreateRegion() {
            return new SingleActiveRegion();
        }
    }
