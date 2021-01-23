    protected void Page_Load(object sender, EventArgs e)
    {
        MyRepeater1.DataSource = new MyStudent[]
            {
                new MyStudent()
                    {
                        ID = 1,
                        StudentName = "Student 1"
                    },
                new MyStudent()
                    {
                        ID = 2,
                        StudentName = "Student 2"
                    }
            };
        MyRepeater1.DataBind();
    }
    protected void MyDeleteButton_Command(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Delete":
                // stuff for deleting by e.CommandArgument
                break;
        }
    }
