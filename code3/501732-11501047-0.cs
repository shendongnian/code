    DataTemplate[] tempDataTemplate = new DataTemplate[ds.Temp.Tables[0].Rows.Count]();
    for(int i = 0; i< dsTmp.Tables[0].Rows.Count; i++)
                {
                 
                 tempDataTemplate[i] =   new DataTemplate
                                                 {
                                                 lblText = "Count: ",
                                                 txtBoxContent = dsTmp.Tables[0].Rows[i][0].ToString();
                                                 }
                }
    
    base.DataContext = tempDataTemplate;
