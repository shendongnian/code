    public async void getdata(String Z,bool b)
                {
                    var query = ParseObject.GetQuery("Maintenances")
               .WhereEqualTo("z", "b");
                    IEnumerable<ParseObject> results = await query.FindAsync();
        
        
        
                    foreach (var record in results)
                    {
                        Console.WriteLine("in for each");
                        var docket = record.Get<String>("Docket");
                        Console.WriteLine(docket);
                    }
                }
