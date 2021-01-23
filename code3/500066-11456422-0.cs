    private void AssignHandlersForControlCollection(
           Control.ControlCollection coll)
      {
          foreach (Control c in coll)
          {
              if (c is TextBox)
                  (c as TextBox).TextChanged 
                    += new EventHandler(SimpleDirtyTracker_TextChanged);
    
              if (c is CheckBox)
                  (c as CheckBox).CheckedChanged 
                    += new EventHandler(SimpleDirtyTracker_CheckedChanged);
    
              // ... apply for other desired input types similarly ...
    
              // recurively apply to inner collections
              if (c.HasChildren)
                  AssignHandlersForControlCollection(c.Controls);
          }
      }
