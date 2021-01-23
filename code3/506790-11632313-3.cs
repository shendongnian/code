     void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
     {
         if (e.PropertyName == "ShowDisabled")
         {
             CustomVariableGroups.Clear();
             foreach (var cvg in AllVariableGroups.Where(x => !x.Disabled))
             {
                 CustomVariableGroups.Add(cvg);
             }
         }
     }
