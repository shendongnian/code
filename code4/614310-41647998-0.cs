                if(TextBoxCusName.Text != "")
                {
                    query = "CustomerName LIKE '%" + TextBoxCusName.Text.Trim()+"%' AND ";
                }
                if(TextBoxCusContact.Text != "")
                {
                    query = query + "CustomerNo LIKE '%" + TextBoxCusContact.Text.Trim() + "%' AND ";
                }
                if(TextBoxVehicleNo.Text != "")
                {
                    query = query + "VehicleNo LIKE '%" + TextBoxVehicleNo.Text.Trim()+"%'";
                }
                if(query.EndsWith("AND "))
                {
                    query = query.Remove(query.Length - 4);
                }
                DataRow[] result = dataCustomerAndVehicle.Select(query);
