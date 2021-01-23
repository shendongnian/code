    public Window8() {
      this.InitializeComponent();
    
      this.Loaded += (sender, args) =>
                        {
                          var cellStyle = this.FindResource("CellStyle") as Style;
                          this.dg.CellStyle = cellStyle;
                          this.dg.SelectedIndex = 0;
                        };
    }
    
    <Window.Resources>
      <Style x:Key="CellStyle"
              TargetType="{x:Type DataGridCell}">
        <Style.Triggers>
          <Trigger Property="IsSelected"
                    Value="True">
            <Setter Property="Background"
                    Value="Yellow" />
            <Setter Property="Foreground"
                    Value="Black" />
          </Trigger>
        </Style.Triggers>
      </Style>
    </Window.Resources>
