     public static class StringBuilderExtensions {
        
        public static StringBuilder Root(this StringBuilder builder) {
          Asserts.IsNotNull(builder);
         builder.Append("/");
         return builder;
        }
       public static StringBuilder And(this StringBuilder builder) {
         Asserts.IsNotNull(builder);
         builder.Append("and");
         return builder;
       }
       //...etc
     }
