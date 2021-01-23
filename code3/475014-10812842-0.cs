    <StackPanel>
            <Expander Header="Expander"
                      Name="expander"
                      Collapsed="OnCollapsed"
                      IsExpanded="True" >
                <StackPanel>
                    <TextBox Text="Text1" Name="textBox1" />
                    <TextBox Text="Text2" Name="textBox2"  />
                    <TextBox Text="Text3" Name="textBox3"  />
                </StackPanel>
            </Expander>
            <TextBox Text="Text4" Name="textBox4" />
    </StackPanel>
    
    in the code behind:
    public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                this.Loaded += delegate
                {
                    textBox2.Focus();
                };
            }
            private void OnCollapsed(object sender, RoutedEventArgs e)
            {
                var element = Keyboard.FocusedElement;
                if (element != null)
                {
                    //now is the ToggleButton inside the Expander get keyboard focus
                    MessageBox.Show(element.GetType().ToString());
                }
                //move focus
                Keyboard.Focus(textBox4);
            }
    }
 
