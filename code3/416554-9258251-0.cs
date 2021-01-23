    namespace System
    {
      public static class MyExtensions
      {
        public static string Report<T>(this T instance)
        {
          StringBuilder sb = new StringBuilder();
          foreach (PropertyInfo prop in typeof(T).GetProperties())   
          {   
            sb.AppendLine(
              string.Format("{0} = {1}", prop.Name, prop.GetValue(si, null));   
          }   
          foreach (FieldInfo prop in typeof(T).GetFields())   
          {   
            sb.AppendLine(
              string.Format("{0} = {1}", prop.Name, prop.GetValue(si, null));   
          }   
          return sb.ToString(); 
        }
      }
    }
