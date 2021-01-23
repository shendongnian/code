    protected void btnSubmit_Click(object sender, EventArgs e)
    {
          var host = new Host
              {
                  Name = "myname",
                  Mac = "mymac"
              };
          dal.AddHost(host)
    }
