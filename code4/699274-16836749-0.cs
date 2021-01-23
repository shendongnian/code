    class MyFormsClass
    {
        // declare textboxes at class level
        TextBox[] passengerBoxes;
        public void createPassengerBoxes(int numPassenger)
        {
           passengerBoxes = new TextBox[numPassenger];
           ...
        }
        public void OnButtonClick(...)
        {
            if (passengernBoxes != null)
            {
                 foreach (TextBox txt in passengerBoxes)
                 {
                     // do something with textboxes
                 }
            }
        }
        ...
    }
