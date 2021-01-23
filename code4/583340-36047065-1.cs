    namespace WpfApplication1
    {    
    public class UI
        {
            MainWindow Form = Application.Current.Windows[0] as MainWindow;
            //Bear in mind the array! Ensure it's the correct Window you're trying to catch.
        
            public void Start()
            {
                Form.Label1.Content = "Yay! You made it!";
                Form.Top = 0;
                Form.Button1.Width = 50;
                //Et voilá! You have now access to the MainWindow and all it's controls
                //from a separate class/file!
                CreateLabel(text, count); //Creating a control to be added to "Form".
            }
            private void CreateLabel(string Text, int Count)
            {
                Label aLabel = new Label();
                aLabel.Name = Text.Replace(" ", "") + "Label";
                aLabel.Content = Text + ": ";
                aLabel.HorizontalAlignment = HorizontalAlignment.Right;
                aLabel.VerticalAlignment = VerticalAlignment.Center;
                aLabel.Margin = new Thickness(0);
                aLabel.FontFamily = Form.DIN;
                aLabel.FontSize = 29.333;
                
                Grid.SetRow(aLabel, Count);
                Grid.SetColumn(aLabel, 0);
                Form.MainGrid.Children.Add(aLabel); //Haha! We're adding it to a Grid in "Form"!
            }
            
        }
    }
