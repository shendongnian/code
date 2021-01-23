        /// <summary>
        /// Bind dropdownlist2 
        /// </summary>
        /// <param name="selectedCountry"></param>
        protected void BindDropDownList(string selectedCountry)
        {
            ProfileMasterBLL bll = new ProfileMasterBLL();
            foreach (var VARIABLE in ProfileMasterDAL.bindcountry())
            {
                if (VARIABLE.ToString().Contains(selectedCountry))
                {
                    var query = (ProfileMasterDAL.GetStatesByCountrys(selectedCountry));
                    DropDownList2.DataSource = query;
                    DropDownList2.DataBind();
                }
            }
        }
