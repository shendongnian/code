    public class BaseClass
    {
        public string Test
        {
            get { 
                var attr = typeof(Test).GetMembers().Where(x => x.Type == this.GetType()).First().GetCustomAttributes(true);
                return null;
            }
        }
    }
