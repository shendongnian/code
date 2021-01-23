    public void BindData(List<MyData> list)
    {
         //Assuming list is not null
         var dataFromSecondColumn = list.Select(l=>l.Name).ToList();
         //Reset of your code.  
         comboBox1.DataSource = dataFromSecondColumn;
    }
