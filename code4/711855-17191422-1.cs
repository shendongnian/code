    public static void ControlsReadOnly(Control[] containerList, bool readOnlyStatus)
    {
         foreach (var control in container.Controls)
         {
              foreach (var control in container.Controls)
              {
                  if((control as RadTextBox) != null)
                  {
                     control.Enabled = !readOnlyStatus; 
                  }
              }
         }
    }
 
