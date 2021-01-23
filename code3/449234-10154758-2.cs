            DatabaseConnection AllPotentials = new DatabaseConnection();
            var newZoho = AllPotentials.Table.DefaultView;
            var poster = new ZohoPoster(ZohoPoster.Fields.Potentials, zohoPoster.Calls.insertRecords);
            newZoho.RowFilter = "IsNull(ZohoID,'zoho') = 'zoho'";
            poster.Debugging = !UseZoho; //UseZoho= false which turns debugging on
            for (int i = 0; i < 1; i++)//newZoho.Count; i++)
            {
                var xmlString = Potential.GetPotentialXML(newZoho[i]);
                Console.WriteLine("Sending New Records to Zoho: {0}", xmlString);
                poster.PostItem.Set("xmlData", xmlString);
                var result = poster.Post(3);
                Console.WriteLine(result);
                if (!string.IsNullOrEmpty(result))
                {
                    try
                    {
                        newZoho[i].Row["ZohoID"] = ReadResult(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to update: {0}", ex.Message);
                    }
                }
            }
            try
            {
                Console.Write("Trying to update the database after getting zoho: ");
                AllPotentials.Update(); 
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed: {0}", ex.Message);
            }
