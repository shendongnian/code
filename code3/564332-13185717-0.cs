        public void InstantiateIn(System.Web.UI.Control container)
        {
           Page myPage = new Page();
           Control userControl = myPage.LoadControl("~/Templates/Edit.ascx");
           //this is the important part
           if (userControl is Edit)
           {
               Edit customControl = userControl as Edit;
               customControl.MyObject= this.PersistedObject;
           }
            container.Controls.Add(userControl);
        }
