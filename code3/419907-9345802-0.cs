                private ContextName context;
                private LoadOperation LoadGardenWater;
                private void GetGardenWater()
                {
                    context = new ContextName();
                    context.GardenWaters.Clear();
                    var query = context.GetGardenWaterQuery();
                    LoadGardenWater = context.Load<GardenWater>(query);
                    LoadGardenWater.Completed +=new EventHandler(LoadGardenWater_Completed);
                }
                
                void LoadGardenWater_Completed(object sender, EventArgs e)
                {
                    List<Customer> cust = new List<Customer>();
                    if (LoadGardenWater.Entities != null || LoadGardenWater.Entities.Count()> 0)
                    {
                        foreach (GardenWater item in LoadGardenWater.Entities)
                        {
                            cust.Add(new Customer()
                            {
                                Amount = Convert.ToInt32(item.Amount),
                                Date = Convert.ToDateTime(item.Date)
                            });
    } 
    }
    }
