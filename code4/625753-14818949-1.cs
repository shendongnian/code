        //Get my objects and subscribe to their property change event
        MyObjects = GetMyObjects();
        foreach (var item in MyObjects)
        {
            item.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == "Value")
                    {
                        Average = MyObjects.Average(x.Value);
                    }
                };
        }
