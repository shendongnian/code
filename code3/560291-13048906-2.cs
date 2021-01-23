      private DateTime btnClick1 ;
            private DateTime btnClick2;
      private void btn_Click(object sender, EventArgs e)
            {
                if (btnClick1==null)
                {
                    btnClick1 = DateTime.Now;
                }
                else
                {
                    btnClick2 = DateTime.Now;
                }
            }
