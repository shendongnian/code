    protected virtual void OnControlRemoved(ControlEventArgs e)
    {
        BeginInvoke((Action)(()=>
            {
               if(Controls.Count() == 0)
               {
                  ...
               }
            }));
        }
