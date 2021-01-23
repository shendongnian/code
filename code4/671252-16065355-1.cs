    private void button3_Click(object sender, EventArgs e)
    {
        MyLinqDataContext MyData = new MyLinqDataContext();
        var myLambda =  MyData.MyLists.Where(lambda => lambda.First_Name.StartsWith(TxtFirstName.Text));
        resultsBox.DataSource = myLambda;
    }
