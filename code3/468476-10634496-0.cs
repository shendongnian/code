        public void Load()
        {
            //set up combobox, bind to countries
            ComboBox comboBox = new ComboBox();
            comboBox.DataSource = GetCountries(ds);
            comboBox.DisplayMember = "Name";
            //when comboBox selection changed, load countries based on selected object
            comboBox.SelectedIndexChanged += (o, s) =>
            {
                var countrySelected = (Country)comboBox.SelectedItem;
                //populate countries based on selection
            };
        }
        /// <summary>
        /// Build a list of countries, based upon the rows in a resulting dataset
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public List<Country> GetCountries(DataSet set)
        {
            List<Country> result = new List<Country>();
            foreach (DataRow row in set.Tables[0].Rows)
            {
                result.Add(new Country()
                {
                    ID = (int)row.ItemArray[0],
                    Name = (string)row.ItemArray[1]
                });
            }
            return result;
        }
