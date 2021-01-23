        class employee
        {
            public Dictionary<string, object> properties = new Dictionary<string,object>();
            public employee()
            {
                properties.Add("time", DateTime.Now);
                properties.Add("name", "Bill Gates");
            }
        }
