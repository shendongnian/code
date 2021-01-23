            var potentials = Server.GetNewPotentials(); //loads all records from server
            for (int i = 0; i < potentials.Length; i++)
            {
                var filter = AllPotentials.DefaultView;
                var result1 = CheckSoidOrSource(potentials[i].Soid, true);
                var result2 = CheckSoidOrSource(potentials[i].SourceID,false) ;
                //This potential can't be found at all so let's add it to our table
                if (result1+result2==0)
                {
                    Logger.WriteLine("Found new record. Adding it to DataTable and sending it to Zoho");
                    AllPotentials.Add(potentials[i]);
                    filter.RowFilter = string.Format("Soid = '{0}'", potentials[i].SourceID);
                    var index = AllPotentials.Rows.IndexOf(filter[0].Row);
                    ZohoPoster posterInsert = new ZohoPoster(Zoho.Fields.Potentials, Zoho.Calls.insertRecords);
                    AllPotentials.Rows[index]["ZohoID"] = posterInsert.PostNewPotentialRecord(3, filter[0].Row);
                }
                //This potential is not found, but has a SourceId that matches a Soid of another record.
                if (result1==0 && result2 == 1)
                {
                    Logger.WriteLine("Found a record that needs to be updated on Zoho");
                    ZohoPoster posterUpdate = new ZohoPoster(Zoho.Fields.Potentials, Zoho.Calls.updateRecords);
                    filter.RowFilter = string.Format("Soid = '{0}'", potentials[i].SourceID);
                    var index = AllPotentials.Rows.IndexOf(filter[0].Row);
                    AllPotentials.Rows[index]["Soid"] = potentials[i].Soid;
                    AllPotentials.Rows[index]["SourceId"] = potentials[i].SourceID;
                    AllPotentials.Rows[index]["PotentialStage"] = potentials[i].PotentialStage;
                    AllPotentials.Rows[index]["UpdateRecord"] = true;
                    AllPotentials.Rows[index]["Amount"] = potentials[i].Amount;
                    AllPotentials.Rows[index]["ZohoID"] = posterUpdate.UpdatePotentialRecord(3, filter[0].Row);
                }
            }
            AllPotentials.AcceptChanges();
        }
        private int CheckSoidOrSource(string Soid, bool checkSource)
        {
            var filter = AllPotentials.DefaultView;
            if (checkSource)
                filter.RowFilter = string.Format("Soid = '{0}' OR SourceId = '{1}'",Soid, Soid);
            else
                filter.RowFilter = string.Format("Soid = '{0}'", Soid);
            
            return filter.Count;
        } 
