    Public Sub New(model As ModuleAViewOneViewModel)
        InitializeComponent()
        AddHandler Loaded, Sub(s, e) 
                              DataContext = model
                           End Sub
    End Sub
