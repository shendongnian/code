        private Boolean InProgress;
        private void OnLookupWeight_TextChanged<T>(object sender, EventArgs e)
        {
            if (!InProgress)
            {
                InProgress=true;
                var controls = GetAll(tabPageSpecifications, typeof(T));
                foreach (var control in controls)
                {
                     if (control.Tag != null)
                         if (control.Tag.ToString() == "Weight")
                             if(control.Name != (sender as LookUpEdit).Name)
                                 (control as LookUpEdit).EditValue = (sender as LookUpEdit).Text;
                }
                InProgress = false;
            }
        }
  
