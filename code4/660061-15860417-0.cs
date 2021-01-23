    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    namespace LongListSelectorDemo.Model
    {
        public class StringKeyGroup<T> : ObservableCollection<T>
        {
            public delegate string GetKeyDelegate(T item);
            public string Key { get; private set; }
            public StringKeyGroup(string key)
            {
                Key = key;
            }
            public static ObservableCollection<StringKeyGroup<T>> CreateGroups(IEnumerable<T> items, CultureInfo ci, GetKeyDelegate getKey, bool sort)
            {
                var list = new ObservableCollection<StringKeyGroup<T>>();
                foreach (var item in items)
                {
                    var index = -1;
                    for (var i = 0; i < list.Count; i++)
                    {
                        if (list[i].Key.Equals(getKey(item)))
                        {
                            index = i;
                            break;
                        }
                    }
                    if (index == -1)
                    {
                        list.Add(new StringKeyGroup<T>(getKey(item)));
                        index = list.Count - 1;
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
