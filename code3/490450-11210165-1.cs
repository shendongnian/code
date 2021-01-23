    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace SO_StringAggregate
    {
        public class ViewModel
        {
            public ViewModel()
            {
                // populate the data set
                var dataSet = new NorthwindDataSet();
                using (var customersAdp = new NorthwindDataSetTableAdapters.CustomersTableAdapter())
                using (var ordersAdp = new NorthwindDataSetTableAdapters.OrdersTableAdapter())
                {
                    customersAdp.Fill(dataSet.Customers);
                    ordersAdp.Fill(dataSet.Orders);
                }
    
                // populate your domain objects
                var customers = dataSet.Customers.ToArray().Select(cust => new Customer
                {
                    Name = cust.Company_Name,
                    Orders = cust.GetOrdersRows().Select(order => new Order { Id = order.Order_ID })
                });
    
                this.Customers = customers;
    
                // build the report
                StringBuilder report = new StringBuilder();
                string formatString = "{0,-30}|{1}";
    
                report.Append(string.Format(formatString, "Name", "Order Ids"));
                report.Append(Environment.NewLine);
                Customers.ToList().ForEach(cust => report.AppendLine(string.Format(
                    formatString, 
                    cust.Name, 
                    string.Join(",", cust.Orders.Select(o => o.Id).ToArray()))
                    ));
    
                // display the report
                Report = report.ToString();
            }
    
            public IEnumerable<Customer> Customers { get; set; }
    
            public string Report { get; set; }
    
        }
    }
