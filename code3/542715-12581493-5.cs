        public void ButtonOnAction(IRibbonControl control)
        {
            switch (control.Id)
            {
                case "myButton1":
                case "myButton2":
                    // do something
                    Console.Out.WriteLine("Button ID: {0}", control.Id);
                    break;
            }
        }
