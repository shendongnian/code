        private delegate void ToUseDelegate();
        
        ToUseDelegate delegateIfNoText = delegate{
           MessageBox.Show("Please Enter Location");
        }
        ToUseDelegate delegateIfText = delegate{
           List<SearchLocation> locationsArray = new List<SearchLocation>();
           var location = locNameTxtBx.Text;
           SearchLocation loc = new SearchLocation();
           loc.Where = location;
           locationsArray.Add(loc);
           mapArea.VE_FindLocations(locationsArray, true, true, null);
           mapArea.VE_SetZoomLevel(14);
        }
        ToUseDelegate delToUse = delegateIfNoText;
        private void locNameTxtBx_TextChanged(object sender, EventArgs e)
        {
           this.AcceptButton = searchBtn;
           if (locNameTxtBx.Text != ""){
              delegateToUse = delegateIfNoText;
           } else {
              delegateToUse = delegateIfText;
           }
        }
        private void searchBtn_Click_1(object sender, EventArgs e)
        {
           delegateToUse();
        }
