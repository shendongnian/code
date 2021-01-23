    string stateId = null;
            var states = new string[] { "bla", "bla2", "bla3" };
            for (int i = 0; i < states.Length; i++)
            {
                var stateType = states[i]; // get property by doing .Type;
                if (stateType == "Article")
                {
                    stateId = states[i]; // get the Id by doing .Id;
                    break;
                }
            }
