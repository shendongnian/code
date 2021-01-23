    var simpleCountries = new List<int> 
                    {
                        1,  // UK
                        12,  // Australia
                        29,  // Brazil
                        56,   // Brunei
                        //..
                        //..
                        215,   //USA
				        221   //Vietnam
                    };
    var postCodeVerifier = new PostCodeVerifyMandatory();
    // 1 rule for simple countries
    postCodeVerifier.Rules.Add((id, region) => simpleCountries.Contains(id)); 
    // Special rule for Ireland
    postCodeVerifier.Rules.Add((id, region) => id == 232 && region.Equals("Dublin")); 
    var a = postCodeVerifier.IsPostCodeRequired(232, "Dublin");
