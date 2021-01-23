            //set name
            if(string.IsNullOrEmpty(txtName.Text)) MessageBox.Show("please enter a customer name");
            else theVisit.name = txtName.Text;
            //set address
            if(string.IsNullOrEmpty(txtAddress.Text)) MessageBox.Show("please enter a customer address");
            else theVisit.address = txtAddress.Text;
            //set arrival time
            if(string.IsNullOrEmpty(txtArrival.Text)) MessageBox.Show("please enter an arrival time");
            else {
                DateTime dt = default(DateTime);
                bool successParse = DateTime.TryParse(txtArrival.Text, out dt);
                if(!successParse) MessageBox.Show("please enter a valid arrival time");
                else theVisit.arrival = dt;
            }
