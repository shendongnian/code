    private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
            {
                if (e.Column.Name != "Active")
                    return;
    
                var person = gridView1.GetFocusedRow() as Person;
                person.Active = Convert.ToBoolean(e.Value);
            }
