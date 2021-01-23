        protected void Page_Load(object sender, EventArgs e)
        {
            List<object> foo1Objects = new List<object>();
            foo1Objects.Add(new { Foo1 = "Hello" });
            foo1Objects.Add(new { Foo1 = "World" });
            GridView1.DataSource = foo1Objects;
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Repeater rep1 = e.Row.FindControl("Repeater1") as Repeater;
            if (rep1 != null)
            {
                List<object> fooFiveObjects = new List<object>();
                fooFiveObjects.Add(new { FooFive = "Apple" });
                fooFiveObjects.Add(new { FooFive = "Orange" });
                fooFiveObjects.Add(new { FooFive = "Banana" });
                rep1.DataSource = fooFiveObjects;
                rep1.DataBind();
            }
        }
