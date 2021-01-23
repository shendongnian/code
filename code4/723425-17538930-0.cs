        Form1_Load()
        {
            Cursor.Position = element's position;
            Timer.Start();
        }
        
        Timer_Tick()
        {
            AutomationElement element = AutomationElement.FromPoint(new System.Windows.Point(mouse.X, mouse.Y));
                string current = element.Current.Name;
            Console.WriteLine(current); //log in text file...
        }
