        DataTable data=null;
        sql = "select library_issue.STUDENTCODE,library_issue.studentname,library_book.bookname,library_issue.issuedate,library_issue.returndate from library_issue             join library_book on library_book.book_id = library_issue.book_id where library_issue.returndate ='" + objct1[j].ToString("dd/MM/yyyy") + "'";
        ds = obj.openDataset(sql, Session["SCHOOLCODE"].ToString());
        Label1.Text = (ds.Tables[0].Rows.Count).ToString();
    for (int j = 0; j < dtgreater.Count; j++)
    {
       if(data.Columns.count==0)
        {
        data = new DataTable();
        data.Columns.Add("STUDENTCODE", typeof(int));
        data.Columns.Add("Studentname", typeof(string));
        data.Columns.Add("Bookname", typeof(string));
        data.Columns.Add("Issuedate", typeof(string));
        data.Columns.Add("Returndate", typeof(string));
        data.Columns.Add("NO of Days Exceeded", typeof(string));
        }
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            TimeSpan ts = objct1[j] - objct2;
            Label1.Text = ts.ToString("dd");
            data.Rows.Add(ds.Tables[0].Rows[i]["STUDENTCODE"], ds.Tables[0].Rows[i]["studentname"], ds.Tables[0].Rows[i]["bookname"], ds.Tables[0].Rows[i]["issuedate"], ds.Tables[0].Rows[i]["returndate"], ts.ToString("dd"));
        }
    }
     return data;
} `
