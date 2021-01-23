            DataTable Booking = new DataTable();
            Booking.Columns.AddRange(new DataColumn[]{ new DataColumn("ID"), new DataColumn("BookingNumber"), new DataColumn("ReferenceNo"), new DataColumn("Name"), new DataColumn("Address") });
            DataTable BookingDetail = new DataTable();
            BookingDetail.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("BookingID"), new DataColumn("OrderItem") });
            Booking.Rows.Add(32, 12120001, "ABCED11212280007", "Customer Name1", "Customer Address");
            BookingDetail.Rows.Add(206, 32, "Item1");
            BookingDetail.Rows.Add(207, 32, "Item2");
            Booking.Rows.Add(33, 12120002, "ABCED11212280008", "Customer Name2", "Customer Address2");
            BookingDetail.Rows.Add(208, 33, "Item1");
            BookingDetail.Rows.Add(209, 33, "Item2");
            BookingDetail.Rows.Add(210, 33, "Item3");
            XElement root = new XElement("Root");
            // For each row from Booking add one CompleteBooking element
            foreach(DataRow BookingRow in Booking.Rows.Cast<DataRow>())
            {
                XElement xeCompleteBooking = new XElement("CompleteBooking");
                
                XElement xeBooking = new XElement("Booking");
                int BookingID = Convert.ToInt32(BookingRow["ID"]);
                IEnumerable<string> columnNames_Booking = Booking.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
                // Add element under Booking element for every column of table
                foreach (string colName in columnNames_Booking)
                    xeBooking.Add(new XElement(colName, BookingRow[colName]));
                xeCompleteBooking.Add(xeBooking);
                IEnumerable<string> columnNames_BookingDetail = BookingDetail.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
                // For Booking.ID find all BookingDetail rows according to BookingDetail.BookingID
                IEnumerable<DataRow> details = BookingDetail.Rows.Cast<DataRow>().Where(BookingDetailRow => Convert.ToInt32(BookingDetailRow["BookingID"]) == BookingID);
                foreach (DataRow BookingDetailRow in details)
                {
                    XElement xeBookingDetail = new XElement("BookingDetail");
                    // Add element under BookingDetail element for every column of table
                    foreach (string colName in columnNames_BookingDetail)
                        xeBookingDetail.Add(new XElement(colName, BookingDetailRow[colName]));
                    xeCompleteBooking.Add(xeBookingDetail);
                }
                root.Add(xeCompleteBooking);
            }
            string xml = root.ToString();
