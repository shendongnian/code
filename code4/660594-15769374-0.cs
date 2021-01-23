    public Page_Load()
    {
        listBox.DataSource = Enum.GetValues(typeof(Student.Classes.Enum.Enum.gender));
        listBox.DataBind();
    }
