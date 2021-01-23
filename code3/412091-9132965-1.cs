    class something 
    {
      public string someImage {...}
    }
    
    <DataTemplate> <!--------- the data context of this item is an instance of
                               my "something" class, so i need to set the path
                               to be the property on the object --->
       <Image Source="{Binding Path=someImage}" />
    </DataTemplate>
