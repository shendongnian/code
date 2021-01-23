    public class DataCacher
    {
        private static String data;
        private static DateTime updateTime;
        private DataCacher() { }
        public static String Data
        {
            get
            {
                if (data == null || updateTime > DateTime.Now)
                {
                    data = "Insert method that requests your data form DB here: GetData()";
                    updateTime = DateTime.Now.AddDays(1);
                }
                return data;
            }
        }
    }
