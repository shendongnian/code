    public MainWindow() 
    { 
         InitializeComponent();
         button1.Click += button1_click; //'+' button
    }
    private void button1_click(object sender, RoutedEventArgs e)
    {
        int antwoord;
        int getal = Convert.ToInt32(TextDoos.Text);
        int getal2 = Convert.ToInt32(TextDoos2.Text);
    
        antwoord = getal + getal2;
        resultTextBox.Text = antwoord ;
    }
