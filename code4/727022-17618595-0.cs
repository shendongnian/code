        class Car
        {
            // Car 'has-a' Radio.
            protected Radio radio = new Radio();
            public Radio MyRadio
            {
                get { return radio; }
                set { radio = value; }
            }
            public void TurnOnRadio(bool onOff)
            {
                // Delegate call to inner object.
                MyRadio.TurnOn(onOff);
            }
        }
    
        public class Radio
        {
            public string ModelNumber { get; set; }
            public bool IsOn { get; set; }
    
            public void TurnOn(bool turnOn)
            {
                if (turnOn)
                {
                    if (IsOn)
                        Console.WriteLine("The radio is already on");
                    else
                    {
                        IsOn = true;
                        Console.WriteLine("You turned on the radio");
                    }
                }
                else
                {
                    if (IsOn)
                    {
                        IsOn = false;
                        Console.WriteLine("You turned off the radio");
                    }
                }
    
            }
    
        }
