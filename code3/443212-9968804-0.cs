    [WebMethod]
    public static void DoWork(Dictionary<string, object>[] sites)
    {
        using (MyDataContext db = new MyDataContext()) {
            foreach (var item in sites) {
                db.MyItems.InsertOnSubmit(new MyItem {
                    Url = item("url"),
                    Description = item("description"),
                    Language = item("language")
                });
                db.SubmitChanges();
            }
        }
    }
