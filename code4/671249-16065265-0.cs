    private void button3_Click(object sender, EventArgs e)
        {
            MyLinqDataContext MyData = new MyLinqDataContext();
            MyList myLambda =  MyData.MyLists.Where(lambda => lambda.First_Name.StartsWith(TxtFirstName.Text[0]));
        }
