    string connectString = ConfigurationManager.ConnectionStrings["Sample4ConnectionString"].ToString();
            StudentsModelDataContext db = new StudentsModelDataContext(connectString);
            var studentList = db.Students;
            Table tb = new Table();
            tb.BorderWidth = 3;
            tb.BorderStyle = BorderStyle.Solid;
            tb.ID = "myTable";
            foreach (Student student in studentList)
            {
                TableRow tr = new TableRow();
                
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                TableCell tc5 = new TableCell();
                tc1.Text = student.Name;
                tc1.BorderWidth = 2;
                tr.Cells.Add(tc1);
                tc2.Text = student.Email;
                tc2.BorderWidth = 2;
                tr.Cells.Add(tc2);
                tc3.Text = student.Gender;
                tc3.BorderWidth = 2;
                tr.Cells.Add(tc3);
                tc4.Text = student.BirthDate.ToString();
                tc4.BorderWidth = 2;
                tr.Cells.Add(tc4);
                tc5.Text = student.TotalMarks.ToString();
                tc5.BorderWidth = 2;
                tr.Cells.Add(tc5);
                tb.Rows.Add(tr);
            }
            form1.Controls.Add(tb);
