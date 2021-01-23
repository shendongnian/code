      public static class Extension {
            public static string TextAfter(this string value ,string search) {
                return  value.Substring(value.IndexOf(search) + search.Length);
            }
      }
