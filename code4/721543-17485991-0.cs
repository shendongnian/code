    public class CustomModelBinder : DefaultModelBinder
    {
         protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor)
        {
            if (propertyDescriptor.Name == "Profiles")
            {
                string vals = controllerContext.HttpContext.Request.Form["Profiles[]"];
                Notification notificiation = (Notification)bindingContext.Model;
                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("ID", typeof(int)));
                notificiation.Profiles = table;
                foreach (string strId in vals.Split(",".ToCharArray()))
                {
                    int intId;
                    if (int.TryParse(strId, out intId))
                    {
                        DataRow dr = table.NewRow();
                        dr[0] = intId;
                        table.Rows.Add(dr);
                    }
                }
            }
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
    }
