    var myReader = new ScanReader(this, new List<Regex>
                                                    {
                                                        new Regex(@"296\d{13,13}"),
                                                        new Regex(@"K%.{5,34}"),
                                                        new Regex(@"C%.{5,34}"),
                                                        new Regex(@"E%.{5,34}"),
                                                    });
            myReader.OnDataLoaded += FillControls;
