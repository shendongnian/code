    private void lookUpCompanyPerson_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
    {
          RepositoryItemLookUpEdit props;
          if (sender is LookUpEdit)
          props = (sender as LookUpEdit).Properties;
          else
          props = sender as RepositoryItemLookUpEdit;
    
          if (props != null && (e.Value is int))
          {
              DataRowView row = props.GetDataSourceRowByKeyValue(e.Value) as DataRowView;
                            
              if (row != null)
              {
                  e.DisplayText = String.Format("{0} {1}", row["FirstName"], row["LastName"]);
                                
              }
          }
    }
