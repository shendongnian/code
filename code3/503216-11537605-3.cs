    void SomeClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Contains("Number"))
            {
                (sender as SomeClass).Sum = EvaluateSum(); // put or call the sum logic
            }
        }
