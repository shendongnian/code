            foreach (InvoiceHeader invoiceHeader in invoiceHeaders)
            {
                rrn++;
                if (rrn >= RECORDS_AT_A_TIME)
                {
                    try
                    {
                        db.SaveChanges();
                        rrn = 0;
                    }
                    catch (Exception e)
                    {
                        string errorText = "Error in blah blah\n\n";
                        errorText += "Error: " + e.ToString();
                        Log.Error(errorText);
                // Throw out all of these records so we can move on.
                // Probably not the best solution, but it works.
                        db.Dispose();
                        db = new db_Entities();
                    }
                }
            }
