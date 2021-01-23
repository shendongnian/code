    public partial class create_person : System.Web.UI.Page
    {
        public void FormView_InsertItem()
        {
            var p = new Person();
            TryUpdateModel(p);
            if (ModelState.IsValid)
            {
                Response.Write("Name: " + p.Name + "<hr />");
            }
        }
    }
