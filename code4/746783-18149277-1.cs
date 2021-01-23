    private void AddNewLabels(argConnectionString)
    {
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
