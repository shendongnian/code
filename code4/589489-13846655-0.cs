    public class BaseRepository
    {
        public static MyAppContext GetDataContext()
        {
            string ocKey = "ocm_" + HttpContext.Current.GetHashCode().ToString("x");
            
            if (!HttpContext.Current.Items.Contains(ocKey))
                HttpContext.Current.Items.Add(ocKey, new MyAppContext());
            
            return HttpContext.Current.Items[ocKey] as MyAppContext;
        }
    }
