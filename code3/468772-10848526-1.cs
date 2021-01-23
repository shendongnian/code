      private void gp_InicialN_Shown(object sender, EventArgs e)
      {
         if (!DesignMode)
         {
            Rectangle oRect = Screen.GetBounds(this);
            this.Top = (oRect.Height / 2) - (this.Height / 2);
            this.Left = (oRect.Width / 2) - (this.Width / 2);
         }
      }
