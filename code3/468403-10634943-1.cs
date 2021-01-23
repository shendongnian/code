        protected void gdvSubscribers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // trimimg value
            for (int i = 0; i < e.NewValues.Count; i++)
            {
                if (e.NewValues[i] is string)
                {
                    e.NewValues[i] = e.NewValues[i].ToString().Trim();
                }
            }        
        }
