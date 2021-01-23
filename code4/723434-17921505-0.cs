    public DataTable[] ParseXML()
        {
            DataTable dtEmployeeDetails = new DataTable("Employees");
            DataColumn column = new DataColumn("EmpID", typeof(Int32));
            column.AutoIncrement = true;
            dtEmployeeDetails.Columns.Add(column);
            dtEmployeeDetails.Columns.Add("FirstName", typeof(String));
            dtEmployeeDetails.Columns.Add("LastName", typeof(String));
            dtEmployeeDetails.Columns.Add("Location", typeof(String));
            DataTable dtOrderDetails = new DataTable("Orders");
            DataColumn column2 = new DataColumn("ID", typeof(Int32));
            column2.AutoIncrement = true;
            dtOrderDetails.Columns.Add(column2);
            dtOrderDetails.Columns.Add("OrderId", typeof(String));
            dtOrderDetails.Columns.Add("Details", typeof(String));
            XElement elementXML = XElement.Load(@"C:\Users\Guest\Documents\Visual Studio 2012\Projects\ConsoleApplication\Orders.xml");
            IEnumerable<XElement> elem = elementXML.Elements();
            foreach (var employees in elem)
            {
                string firstName = employees.Element("firstname").Value;
                string lastname = employees.Element("lastname").Value;
                string location = employees.Element("location").Value;
                dtEmployeeDetails.Rows.Add(null,firstName, lastname, location);
                //var orders = from order in elementXML.Descendants("order")
                             //select order;
                foreach (var order in employees.Descendants("order"))
                {
                    string orderId = order.Element("orderId").Value;
                    string details = order.Element("details").Value;
                    dtOrderDetails.Rows.Add(null, orderId, details);
                }
            }
            return new DataTable[2] { dtEmployeeDetails,dtOrderDetails };
        }
