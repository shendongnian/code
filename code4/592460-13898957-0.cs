        StreamReader sr = File.OpenText("Customer.csv");
    }
    
    public static void LoadCustomers()
    {
        try
        {
            if (File.Exists("Customer.csv"))
            {
                string temp = null;
                var retList = new List<Customer>();
                using (StreamReader sr = File.OpenText(@"Customer.csv"))
                {
                    while ((temp = sr.ReadLine()) != null)
                    {
                        temp = temp.Trim();
                        string[] lineHolder = temp.Split(',');
                        retlist.add(new Customer(){
                          customerName = linerHolder[0],
                          customerAddress = lineHolder[1],
                          customerZip = Convert.ToInt32(lineHolder[2])
                        });
                    }//end for loop
                }
            }
            else
            {
                File.Create("Customer.csv");
            }
        }
        catch (Exception e)
        {
            System.Windows.Forms.MessageBox.Show("File Loading Error: " + e.Message);
        }
    }
