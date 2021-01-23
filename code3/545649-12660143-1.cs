      public static void SetAllControls( Type t, Control parent /* can be Page */)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == t) c.Visible=true;
                if (c.HasControls())  GetAllControls( t, c);
            }
          
        }
     SetAllControls( typeof(Label), this);
