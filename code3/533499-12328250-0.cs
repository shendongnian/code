    public void ParseXMLToDataTable()
        {
            XElement document = XElement.Parse(
           @"
                <Registrations>
                  <RegistrationForm>
                    <RegValue Id=""Passport"" v=""13.999.567"" />
                    <RegValue Id=""FavoriteColor"" v=""Blue"" />
                    <RegValue Id=""Gender"" v=""Male"" />
                  </RegistrationForm>
                  <RegistrationForm>
                    <RegValue Id=""Passport"" v=""12.566.342"" />
                    <RegValue Id=""FavoriteColor"" v=""Red"" />
                    <RegValue Id=""Gender"" v=""Female"" />
                  </RegistrationForm>
                </Registrations>
            ");
            List<XElement> RegistrationForm = document.Elements("RegistrationForm").ToList();
            if (RegistrationForm.Count > 0)
            {
               DataTable oGridViewTable =  XElementToDataTable(RegistrationForm);
            }
        }
   
    public DataTable XElementToDataTable(List<XElement> oRegistrationFormList)
        {
            DataTable dt = new DataTable();
            // Generate DataTable Column
            XElement oFirstElement = oRegistrationFormList.First();
            dt.Columns.AddRange(oFirstElement.Descendants().Select(o =>
               new DataColumn(o.Attribute("Id").Value)).ToArray());
            //Generate DataTable Rows
            foreach (XElement oRegistrationForm in oRegistrationFormList)
            {
                DataRow dr = dt.NewRow();
                foreach (XElement oRegValue in oRegistrationForm.Descendants())
                    dr[oRegValue.Attribute("Id").Value] = oRegValue.Attribute("v").Value; 
                dt.Rows.Add(dr);
            }
            return dt;
        }
