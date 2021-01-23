     private void btnCreate_Click(object sender, EventArgs e)
        {
            using (testEntities Setupctx = new testEntities())
            {
             string[] stations = StationNameList();
    
             if(stations.Contains(txtStation.Text))
                  {
                  //already exists
                  }
             else
                  {
                  //does not exists
                  //your code to insert the new object
                  }
            }
       }
