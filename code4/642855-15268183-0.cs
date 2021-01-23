    xmlns:MvvmLight_Command="clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras"
    xmlns:Custom="clr-namespace:System.Windows.Interactivity;  assembly=System.Windows.Interactivity"
     <ListBox>
     ...
         <Custom:Interaction.Triggers>
              <Custom:EventTrigger EventName="SelectionChanged ">
                 <MvvmLight_Command:EventToCommand PassEventArgsToCommand="False" Command="{Binding Path=ComputeCommand}"/>
              </Custom:EventTrigger>
         </Custom:Interaction.Triggers>
    </Listbox>
