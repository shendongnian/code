    public class Service : IService
    {
        jqGridModel<GridListItem> IService.GetData()
        {
            jqGridModel<GridListItem> model = new jqGridModel<GridListItem>();
            List<GridListItem> list = new List<GridListItem>();
            GridListItem item = new GridListItem() { Col1 = "1", Col2 = "Dog" };
            list.Add(item);
            
            item = new GridListItem() { Col1 = "2", Col2 = "Cat" };
            list.Add(item);
            model.records = list.Count;
            model.rows = list;
            return model;
        }
        void IService.UpdateData(string id, string oper, string Col1, string Col2)
        {
            //do work here to save the updated data
        }
    }
