    public void PopulateGameBoard()
    {
         XDocument gameFiles = XDocument.Parse(Properties.Resources.Jeopardy);
         IEnumerable<string> categories =
             from category in gameFiles.Descendants("category")
             select (string)category.Attribute("name");
         Label[] cat1HeaderLabel= new Label[100];  
         int i = 0;
           categories.Each(p =>
           {
               cat1HeaderLabel[i] = new Label();
               cat1HeaderLabel[i].Text = p;
               this.Form.Controls.Add(cat1HeaderLabel[i]);
               i++;
           });
    }
