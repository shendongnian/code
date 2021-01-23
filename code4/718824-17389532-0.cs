    <CollectionViewSource x:Key="csv" Source="{StaticResource MotionSequenceCollection}" 
                      Filter="CollectionViewSource_Filter">
        <CollectionViewSource.SortDescriptions>
             <scm:SortDescription PropertyName="your property" Direction="Ascending"/>
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
