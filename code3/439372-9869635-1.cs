     class Class
        {
            MyInterface control;
    
            public Class()
            {
                if (condition == true)
                    control = new UserControl1();
                else
                    control = new UserControl2();
    
                control.LoadXML();
            }
        }
