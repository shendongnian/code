    public class DataTableDictionary
    {
         private static Dictionary<Type, DataView> cachedViews = new Dictionary<Type, DataView>();
         protected abstract DataView CreateView();
         public DataView GetView()
         {
             DataView result;
             if (!cachedViews.TryGetValue(this.GetType(), out result))
             {
                 result = this.CreateView();
                 cachedViews[this.GetType()] = result;
             }
             return result;
         }
    }
    public class ColourDictionary : DataTableDictionary
    {
        protected override DataView CreateView()
        {
            return base.buildView(table: ((App)App.Current).ApplicationData.Colours, keyField: "ColorCode");          
        }
    }
