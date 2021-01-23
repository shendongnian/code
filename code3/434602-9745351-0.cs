    Imports System.Runtime.CompilerServices
    Imports System.Linq.Expressions
    
    Module IQueryableExtensions
    
        <Extension()>
        Public Function ToSelectList(Of T)(source As IEnumerable(Of T), nameExpression As Expression(Of Func(Of T, String)), valueExpression As Expression(Of Func(Of T, String)), selectedExpression As Expression(Of Func(Of T, Boolean)), additionalItems As IEnumerable(Of SelectListItem)) As IEnumerable(Of SelectListItem)
            Return additionalItems.Union(
                source.Select(Function(x) New SelectListItem With {
                                  .Text = nameExpression.Compile.Invoke(x),
                                  .Value = valueExpression.Compile.Invoke(x),
                                  .Selected = selectedExpression.Compile.Invoke(x)
                              }
                          )
                      )
        End Function
    
    End Module
