     public static string IfNullOrEmpty(this string instance, string alt){
       return string.IsNullOrEmpty(instance) ? alt : instance;
     }
     var str1 = "".IfNullOrEmpty("foo"); //'foo'
     var str2 = ((string)null).IfNullOrEmpty("bar"); //'bar'
     var str3 = "Not null or empty".IfNullOrEmpty("not used"); //'not null or empty'
