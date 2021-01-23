      public string DescName 
      {
          get 
          {
               return Description + " " + Name;
          }
      {
    <GridViewColumn Width="300" Header="Name" DisplayMemberBinding="{Binding DescName}" />
