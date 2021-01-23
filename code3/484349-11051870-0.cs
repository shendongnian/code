    var myQueryExpression = new QueryExpression
                                    {
                                        EntityName = "server",
                                        ColumnSet = new ColumnSet(new[]{
                                            "latest_maintenance", 
                                            "maintenance_interval"})
                                    };
    myQueryExpression.AddOrder("latest_maintenance", OrderType.Ascending);
    myQueryExpression.AddOrder("maintenance_interval", OrderType.Ascending);
