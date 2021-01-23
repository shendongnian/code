    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                var student = e.Row.DataItem as Student;
                var dataList = e.Row.FindControl("DataList1") as DataList;
                dataList.DataSource = student.Marks;
                
                dataList.DataBind();
            }
        }
