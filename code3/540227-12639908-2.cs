    var countries = new Dictionary<int, string> 
                    {
                        { 1, null },      // UK
                        { 12, null },     // Australia
                        { 29, null },     // Brazil
                        { 56, null },     // Brunei
                        //..
                        //..
                        { 215, null },    //USA
				        { 221, null },    //Vietnam
                        { 232, "Dublin" } // Ireland
                    };
    var postCodeVerifier = new PostCodeVerifyMandatory();
    // 1 rule for all
    postCodeVerifier.Rules.Add((id, region) => 
                                  countries.ContainsKey(id) && 
                                  (countries[id] ?? region) == region);
