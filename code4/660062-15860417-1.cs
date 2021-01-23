    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using Microsoft.Phone.Globalization;
    namespace LongListSelectorDemo.Model
    {
        public class AlphaKeyGroup<T> : ObservableCollection<T>
        {
            /// <summary>
            /// The delegate that is used to get the key information.
            /// </summary>
            /// <param name="item">An object of type T</param>
            /// <returns>The key value to use for this object</returns>
            public delegate string GetKeyDelegate(T item);
            /// <summary>
            /// The Key of this group.
            /// </summary>
            public string Key { get; private set; }
            /// <summary>
            /// Public constructor.
            /// </summary>
            /// <param name="key">The key for this group.</param>
            public AlphaKeyGroup(string key)
            {
                Key = key;
            }
            /// <summary>
            /// Create a list of AlphaGroup<T> with keys set by a SortedLocaleGrouping.
            /// </summary>
            /// <param name="slg">The </param>
            /// <returns>Theitems source for a LongListSelector</returns>
            private static ObservableCollection<AlphaKeyGroup<T>> CreateGroups(SortedLocaleGrouping slg)
            {
                return new ObservableCollection<AlphaKeyGroup<T>>(slg.GroupDisplayNames.Select(key => new AlphaKeyGroup<T>(key)).ToList());
            }
            /// <summary>
            /// Create a list of AlphaGroup<T> with keys set by a SortedLocaleGrouping.
            /// </summary>
            /// <param name="items">The items to place in the groups.</param>
            /// <param name="ci">The CultureInfo to group and sort by.</param>
            /// <param name="getKey">A delegate to get the key from an item.</param>
            /// <param name="sort">Will sort the data if true.</param>
            /// <returns>An items source for a LongListSelector</returns>
            public static ObservableCollection<AlphaKeyGroup<T>> CreateGroups(IEnumerable<T> items, CultureInfo ci, GetKeyDelegate getKey, bool sort)
            {
                var slg = new SortedLocaleGrouping(ci);
                var list = CreateGroups(slg);
                foreach (var item in items)
                {
                    var index = 0;
                    if (slg.SupportsPhonetics)
                    {
                        //check if your database has yomi string for item
                        //if it does not, then do you want to generate Yomi or ask the user for this item.
                        //index = slg.GetGroupIndex(getKey(Yomiof(item)));
                    }
                    else
                    {
                        index = slg.GetGroupIndex(getKey(item));
                    }
                    if (index >= 0 && index < list.Count)
                    {
                        list[index].Add(item);
                    }
                }
                if (sort)
                {
                    foreach (var group in list)
                    {
                        group.ToList().Sort((c0, c1) => ci.CompareInfo.Compare(getKey(c0), getKey(c1)));
                    }
                }
                return list;
            }
        }
    }
