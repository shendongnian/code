    public partial class _Default : System.Web.UI.Page
    {
        // Dummy data class. We'll bind a list of these to the repeater.
        class File
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public List<string> AListOfStrings { get; set; }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            rptrTest.ItemDataBound +=
                new RepeaterItemEventHandler(rptrTest_ItemDataBound);
        }
        private DropDownList file1DropDown;
        void rptrTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Find the DropDownList in the repeater's ItemTemplate
            // so we can manipulate it.
            DropDownList ddlSelect =
                e.Item.FindControl("ddlSelect") as DropDownList;
            File dataItem = (File)e.Item.DataItem;
            DropDownList currentDropDownList;
            switch (dataItem.ID)
            {
                case 1:
                    // Store the current item's DropDownList for later...
                    file1DropDown = ddlSelect;
                    currentDropDownList = file1DropDown;
                    break;
                case 2:
                case 3:
                    currentDropDownList = file1DropDown;
                    break;
                default:
                    currentDropDownList = ddlSelect;
                    break;
            }
            // Get all of the strings starting with the current ID and
            // add them to whichever DropDownList we need to modify.
            currentDropDownList.Items.AddRange((
                from s
                in dataItem.AListOfStrings
                where s.StartsWith(dataItem.ID.ToString())
                select new ListItem(s)).ToArray());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Just build up a list of strings which we can filter later.
            List<string> stringList = new List<string>();
            foreach (string number in (new[] { "1", "2", "3", "4" }))
            {
                foreach (string letter in (new[] { "a", "b", "c", "d", "e" }))
                {
                    stringList.Add(number + " " + letter);
                }
            }
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
    }
