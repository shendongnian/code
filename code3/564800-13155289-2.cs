    protected void Page_Load(object sender, EventArgs e)
    {
        // This is an example, but you should get this data from database
        List<File> myObjects = new List<File>(new[]
        {
            new File { ID = 1, Name = "Foo", AListOfStrings = stringList },
            new File { ID = 2, Name = "Bar", AListOfStrings = stringList },
            new File { ID = 3, Name = "Baz", AListOfStrings = stringList },
            new File { ID = 4, Name = "Quux", AListOfStrings = stringList }
        });
        
        rptrTest.DataSource = myObjects;
        rptrTest.DataBind();
    }
