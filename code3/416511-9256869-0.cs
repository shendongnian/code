    var lists = new [] { column3, column4, column5 };
    Random rand = new Random();
    for ( int n = 0; n < 10; n++ )
    {
       HtmlGenericControl listItem1 = new HtmlGenericControl("li");
       listItem1.Attributes.Add("class", colors[RandString.Next(0, colors.Length -1)]);
       lists[rand.Next(0,lists.Count)].Controls.Add(listItem1);
    }
