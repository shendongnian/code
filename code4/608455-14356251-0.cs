    namespace Web.Models
    {
      [DataContract(IsReference = true)]
      public class Sales
      {
        [DataMember]
        public int SalesId { get; set; }
        [DataMember]
        public int ShowOrder { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public bool Regurgitate { get; set; }
    
        [DataMember]
        public int ForegroundColor { get; set; }
    	
    	[DataMember]
        public SolidColorBrush MyBrush { get; set; }
    
        public Sales(Salese result)
        {
            SalesId = result.SalesId;
            ShowOrder = result.ShowOrder;
            Active = result.Active;
            Regurgitate = result.Regurgitate;            
    
            if (SalesId == 12)
            {
                var bytes = System.BitConverter.GetBytes(ForegroundColor);
                Color btnColor = Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
    
                MyBrush = new SolidColorBrush(btnColor);
    			
            }
       }
    }
----------
    <ListBox Grid.Row="1" Height="Auto" MinHeight="200" Width="160" Margin="2,2,2,2" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" ItemsSource="{Binding Path=CurrentOutcomes}" Background="{x:Null}" BorderBrush="{x:Null}">
          <ListBox.ItemTemplate>
              <DataTemplate>
                   <Button Height="30" Width="150" HorizontalAlignment="Center" Content="{Binding Outcome}" CommandParameter="{Binding SalesOutcomeId }" Command="{Binding Source={StaticResource ViewModel}, Path=OutcomeCommand}" Foreground="{Binding MyBrush}"  />
              </DataTemplate>
          </ListBox.ItemTemplate>
     </ListBox>
