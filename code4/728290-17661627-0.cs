     private void Form1_Load(object sender, EventArgs e)
     {
         List<List> var = new List<List>();
    
         List var1 = new List();
         var1.var = 1;
         var1.var2 = 1;
         var1.var3 = 1;
         var1.var4 = 1;
         var1.var5 = 1;
    
         List var2 = new List();
         var2.var = 1;
         var2.var2 = 1;
         var2.var3 = 1;
         var2.var4 = 1;
         var2.var5 = 1;
    
         List var3 = new List();
         var3.var = 1;
         var3.var2 = 1;
         var3.var3 = 1;
         var3.var4 = 1;
         var3.var5 = 1;
         
         List var4 = new List();
         var4.var = 1;
         var4.var2 = 1;
         var4.var3 = 1;
         var4.var4 = 1;
         var4.var5 = 1;
    
         var.Add(var1);
         var.Add(var2);
         var.Add(var3);
         var.Add(var4);
    
         InitializeData(var, typeof(List).GetProperties());
     }
    
     private static void InitializeData(List<List> objects, PropertyInfo[] props)
     {
         DateTime start = DateTime.Now;
    
         int count = 0;
         int count2 = 0;
         do
         {
             count = count + 1;
             foreach (var item in objects)
             {
                 var kvp = new Dictionary<string, object>();
    
                 foreach (var p in props)
                 {
                     object returnData = p.GetValue(item, null); //returnProps(p.Name, item);
                 }
             }
             if (count == 50000)
             {
                 count2 = count2 + 1;
                 if (count2 >= 10)
                 {
                     break;
                 }
             }
         } while (count < 50000);
    
    
         TimeSpan timer = new TimeSpan();
         timer = DateTime.Now.Subtract(start);
     }
    
     private class List
     {
         public int var { set; get; }
         public int var2 { set; get; }
         public int var3 { set; get; }
         public int var4 { set; get; }
         public int var5 { set; get; }
         public int var6 { set; get; }
         public int var7 { set; get; }
         public int var8 { set; get; }
         public int var9 { set; get; }
         public int var10 { set; get; }
         public int var11 { set; get; }
         public int var12 { set; get; }
         public int var13 { set; get; }
         public int var14 { set; get; }
     }
     private static object returnProps(string propName, List curObject)
     {
         if (propName == "var")
         {
             return curObject.var;
         }
         else if (propName == "var2")
         {
             return curObject.var2;
         }
         else if (propName == "var3")
         {
             return curObject.var3;
         }
         else if (propName == "var4")
         {
             return curObject.var4;
         }
         else if (propName == "var5")
         {
             return curObject.var5;
         }
         else if (propName == "var6")
         {
             return curObject.var6;
         }
         else if (propName == "var7")
         {
             return curObject.var7;
         }
         else if (propName == "var8")
         {
             return curObject.var8;
         }
         else if (propName == "var9")
         {
             return curObject.var9;
         }
         else if (propName == "var10")
         {
             return curObject.var10;
         }
         else if (propName == "var11")
         {
             return curObject.var11;
         }
         else if (propName == "var12")
         {
             return curObject.var12;
         }
         else if (propName == "var13")
         {
             return curObject.var13;
         }
         else if (propName == "var14")
         {
             return curObject.var14;
         }
    
         return new object();
     }
