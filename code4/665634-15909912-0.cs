    class Person
        {
            Person()
            {
                properties.Add(0, "defaultBirthNo");
            }
            Dictionary<int, string> properties = new Dictionary<int,string>();
            private int birthNo;
	        public int BirthNo
	        {
		        get { return birthNo;}
		        set { 
                    birthNo = value;
                    properties[0] = birthNo.ToString();
                }
	        }
        }
