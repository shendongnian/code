    //create it as static resource and bind your ItemsControl to it
    <CollectionViewSource x:Key="csv" Source="{StaticResource MotionSequenceCollection}" 
                      Filter="CollectionViewSource_Filter">
        <CollectionViewSource.GroupDescriptions>
           <PropertyGroupDescription PropertyName="YYY"/>
        </CollectionViewSource.GroupDescriptions>
        <CollectionViewSource.SortDescriptions>
             <scm:SortDescription PropertyName="YYY" Direction="Ascending"/>
        </CollectionViewSource.SortDescriptions>
    </CollectionViewSource> 
    private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
    {
        var t = e.Item as ModelBase;
        if (t != null)
       
        {
            //use your filtering logic here
            
        }
    }
