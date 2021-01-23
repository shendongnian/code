    Grid SegmentsGrid = new Grid();
    GridRuntimeTemplate AirlinesTemplate = new GridRuntimeTemplate();
    AirlinesTemplate.ID = "AirlinesTemplate1";
    AirlinesTemplate.ControlID = "AirlinesComboBox1";
    AirlinesTemplate.Template = new Obout.Grid.RuntimeTemplate();
    AirlinesTemplate.Template.CreateTemplate += new Obout.Grid.GridRuntimeTemplateEventHandler(CreateAirlinesTemplate);
    GridRuntimeTemplate ClassesTemplate = new GridRuntimeTemplate();
    ClassesTemplate.ID = "ClassesTemplate1";
    ClassesTemplate.ControlID = "ClassesComboBox1";
    ClassesTemplate.Template = new Obout.Grid.RuntimeTemplate();
    ClassesTemplate.Template.CreateTemplate +=new Obout.Grid.GridRuntimeTemplateEventHandler(CreateClassesTemplate);  
    
    SegmentsGrid.Templates.Add(ClassesTemplate);
    SegmentsGrid.Templates.Add(AirlinesTemplate);
      public void CreateAirlinesTemplate(Object sender, Obout.Grid.GridRuntimeTemplateEventArgs e)
        {
            PlaceHolder ph1 = new PlaceHolder();
            e.Container.Controls.Add(ph1);
            
            AirlinesComboBox.ID = "AirlinesComboBox1";
            AirlinesComboBox.Width = Unit.Percentage(100);
            AirlinesComboBox.Height = Unit.Pixel(200);
            AirlinesComboBox.DataTextField = "Airline_Long_Name";
            AirlinesComboBox.DataValueField = "Airline_Long_Name";
            AirlinesComboBox.EmptyText = "Select Airline ...";
            AirlinesComboBox.EnableLoadOnDemand = true;
            AirlinesComboBox.LoadingItems += AirlinesComboBox1_LoadingItems;
            ph1.Controls.Add(AirlinesComboBox);
        }
     protected void AirlinesComboBox1_LoadingItems(object sender, ComboBoxLoadingItemsEventArgs e)
        {
            // Getting the countries
            DataTable data = GetAirlines(e.Text);
            // Looping through the items and adding them to the "Items" collection of the ComboBox
            for (int i = 0; i < data.Rows.Count; i++)
            {
                (sender as ComboBox).Items.Add(new ComboBoxItem(data.Rows[i]["Airline_Long_Name"].ToString(), data.Rows[i]["Airline_Long_Name"].ToString()));
            }
            e.ItemsLoadedCount = data.Rows.Count;
            e.ItemsCount = data.Rows.Count;
        }
      protected void ClassesComboBox1_LoadingItems(object sender, ComboBoxLoadingItemsEventArgs e)
        {
            // Getting the countries
            DataTable data = GetClasses(e.Text);
            // Looping through the items and adding them to the "Items" collection of the ComboBox
            for (int i = 0; i < data.Rows.Count; i++)
            {
                (sender as ComboBox).Items.Add(new ComboBoxItem(data.Rows[i]["Class_Name"].ToString(), data.Rows[i]["Class_Name"].ToString()));
            }
            e.ItemsLoadedCount = data.Rows.Count;
            e.ItemsCount = data.Rows.Count;
        }
        public void CreateClassesTemplate(Object sender, Obout.Grid.GridRuntimeTemplateEventArgs e)
        {
            PlaceHolder ph1 = new PlaceHolder();
            e.Container.Controls.Add(ph1);
            
            ClassesComboBox.ID = "ClassesComboBox1";
            ClassesComboBox.Width = Unit.Percentage(100);
            ClassesComboBox.Height = Unit.Pixel(200);
            ClassesComboBox.DataTextField = "Class_Name";
            ClassesComboBox.DataValueField = "Class_Name";
            ClassesComboBox.EmptyText = "Select Flight Class ...";
            ClassesComboBox.EnableLoadOnDemand = true;
            ClassesComboBox.LoadingItems += ClassesComboBox1_LoadingItems;
            ph1.Controls.Add(ClassesComboBox);
        }
