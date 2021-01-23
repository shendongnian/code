    private void AddNewLabels(argConnectionString)
    {
      int count = 0;
      Point startPoint = new Point(0,0) // assuming this is where you want the first label to be in the scroll box
      labelSpacing = 20; // how far apart vertically should your column of labels be.
      foreach(String labelText in GetCatgoryNames(argConectionString))
      {
          Label label = new Label();
          label.parent = myScrollBox;
          label.Left = StartPoint.X;
          label.Top = Count * LabelSpacing + StartPoint.Y;
          label.Name = String.Concat'MyDynamicLabel'
          // etc
          label.Text = labelText;
          count++;
      }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       DestroyPreviousLabels();
       AddNewLabels(conn.ConnectionString);
    }
