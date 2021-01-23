    public static List<SelectListItem> GetEnumsByType<T>(bool useFriendlyName = false, List<T> exclude = null,
                List<T> eachSelected = null, bool useIntValue = true) where T : struct, IConvertible
            {
                var enumList = from enumItem in EnumUtil.GetEnumValuesFor<T>()
                               where (exclude == null || !exclude.Contains(enumItem))
                               select enumItem;
    
                var list = new List<SelectListItem>();
    
                foreach (var item in enumList)
                {
                    var selItem = new SelectListItem();
    
                    selItem.Text = (useFriendlyName) ? item.ToFriendlyString() : item.ToString();
                    selItem.Value = (useIntValue) ? item.To<int>().ToString() : item.ToString();
    
                    if (eachSelected != null && eachSelected.Contains(item))
                        selItem.Selected = true;
    
                    list.Add(selItem);
                }
    
                return list;
            }
    
            public static List<SelectListItem> GetEnumsByType<T>(T selected, bool useFriendlyName = false, List<T> exclude = null,
                bool useIntValue = true) where T : struct, IConvertible
            {
                return GetEnumsByType<T>(
                    useFriendlyName: useFriendlyName,
                    exclude: exclude,
                    eachSelected: new List<T> { selected },
                    useIntValue: useIntValue
                );
            }
