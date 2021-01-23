     private void DisableExitFormBtn()
        {
            if(DisableBtn!=null)
              {
                EventArgs e = new EventArgs();
                DisableBtn(this, e);
              }
            // need to disable form button here
        }
