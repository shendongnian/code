        protected void btn1_Click(object sender, EventArgs e)
        {
            MyService.Service1 service = new MyService.Service1();
            MyService.Customer customer= service.getCustomer(string id);
            ID = customer.CustomerId;
            // here you can generate XML based on customer object if you really need to do so
            lbl1.Text = GetCustomerXML(customer);// implement method to get XML
        }
        private string GetCustomerXML( MyService.Customer  customer)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(MyService.Customer));
            StringWriter sw= new StringWriter();
            XmlWriter writer = XmlWriter.Create(sw);
            xsSubmit.Serialize(writer, customer);
            return sw.ToString(); 
        }
