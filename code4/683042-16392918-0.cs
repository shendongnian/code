     public void gridfill()
    {
          markSp spMark = new markSp();
         DataTable dtbl = new DataTable();
         dtbl = spMark.markViewAll();
                       
         dtbl = spMark.markViewBySchool(txtSchoolName.Text);
         gvResult.DataSource = dtbl; 
         gvResult.Databind(); // You forgot DataBind()  
      }
