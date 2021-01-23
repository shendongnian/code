    Binding bind = new Binding("Checked", bindingSource5, "SchoolContacted");
    bind.Format += (s,e) => {
        e.Value = (int)e.Value == 1;
        dataRepeater.ItemTemplate.BackColor = ((bool)e.Value) ? Color.Red : Color.White;
    };
    cbSchoolFri.DataBindings.Add(bind);
  
