         List<MyItem> lst = new List<MyItem>();
         lst.Add(new MyItem() { Status = "Pending" });
         lst.Add(new MyItem() { Status = "Error" });
         lst.Add(new MyItem() { Status = "Invalid String" });
         lst.Add(new MyItem() { Status = "Success" });
         var ascList =
            lst.OrderBy((x) => { switch (x.Status) { case "Error": return 0; case "Pending": return 1; case "Success": return 3; default: return 4; } });
         var descList =
            lst.OrderByDescending((x) => { switch (x.Status) { case "Error": return 0; case "Pending": return 1; case "Success": return 3; default: return 4; } });
         Console.WriteLine("Asc\n===");
         foreach (MyItem mi in ascList)
         {
            Console.WriteLine(mi.Status);
         }
         Console.WriteLine("\nDesc\n====");
         foreach (MyItem mi in descList)
         {
            Console.WriteLine(mi.Status);
         }
      }
