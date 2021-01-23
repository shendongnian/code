    namespace Factory
    {
      public interface Iplugin
      {
        void doSomthing(string _str);
      }
    
  
    class Program
    {
        static void Main(string[] args)
        {
            string @namespace = "Plugins";
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == @namespace
                    select t;
            q.ToList();
            List<Iplugin> myList = new List<Iplugin>();
            foreach (var item in q)
            {
                Iplugin temp=(Iplugin)Activator.CreateInstance(item);
                myList.Add(temp);// a list with all my plugins
                
            }
               
            foreach (var item in myList)
            {
               item.doSomthing("string");
                
            }
        }
    }
}
