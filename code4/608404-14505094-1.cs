    Public Views MyViewState { get; set;}
    Public ButtonState MyButtonState { get; set;}
    Public MyData dataclass { get; set;}
    
    Public Form1()
    {
    InitializeComponent();
    MyViewState = Views.First;
    MyButtonState = ButtonState.Start;
    dataclass = new MyData(); //mostly at startup your class data is empty ...
    ControlViews();
    }
    Public void ControlViews()
    {
        //Based on your Buttons you will do what each form is asked to do:
          switch(MyButtonState)
          {
           case ButtonState.Start:
            //Since this is your startup: you only need to show your next view and replace you MyViewState
            MyViewState = Views.First;
            ///code for showing your view
           Break;
           case ButtonState.Next:
            //Since this time you probably filled in data you need to know in which MyViewState you are
             Switch (MyViewState)
             {
              Case Views.First:
               //You want to keep your data
               ///Code for placing data into your dataclass
               //After replacing the code, you then need to do some calculations and open the next view
               ///Code for calculations and placing this data in the form
               ///Code for opening the second view
               MyViewState = Views.Second;
              Break;
               // you then need to do this for each MyViewState
             }
           Break;
          }
    }
