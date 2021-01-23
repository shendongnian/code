    ''' <summary>
    ''' Converts items in the Master list to Items in the target list, and back again.
    ''' </summary>
    Public Interface IListItemConverter
        ''' <summary>
        ''' Converts the specified master list item.
        ''' </summary>
        ''' <param name="masterListItem">The master list item.</param>
        ''' <returns>The result of the conversion.</returns>
        Function Convert(ByVal masterListItem As Object) As Object
    
        ''' <summary>
        ''' Converts the specified target list item.
        ''' </summary>
        ''' <param name="targetListItem">The target list item.</param>
        ''' <returns>The result of the conversion.</returns>
        Function ConvertBack(ByVal targetListItem As Object) As Object
    End Interface
