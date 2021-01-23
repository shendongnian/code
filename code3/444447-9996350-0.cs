    <Window ...>
       <Grid>
           ...
           <!-- These controls are named, so you can access them directly by name -->
           <Button x:Name="btnMyNamedButton" ... />
           <Button Name="btnMyOtherNamedButton" ... />
           <!-- This control is not named, so you can not directly access it by name -->
           <Button ... />
       <Grid>
    </Window>
    public partial class MyWindow : Window
    {
        public MyWindow()
        {
            InitializeComponent();
            //btnMyNamedButton can be accessed
            //btnMyOtherNamedbutton can also be accessed
            //The third button can be accessed, but not directly by name.
        }
    }
