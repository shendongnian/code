    public class Main
    {
        public void BindData()
        {
            List<MyList> myResults = new List<MyList>();
  
            //Add rows from numbercart to list object
            foreach (var item in NumberCart)
            {
                myResults.Add(new MyList { Item = item.item, Price = item.price });
            }
            
            //Add rows from feature cart to list object
            foreach (var item in FeatureCart)
            {
                myResults.Add(new MyList { Item = item.item, Price = item.price });
            }
            //Bind to datagrid
            myDataGrid.DataSource = myResults;
        }
    }
    public class MyList
    {
        public string Item {get; set;}
        public float Price {get; set;}
    }
