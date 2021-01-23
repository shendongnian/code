    Public Interface IQuery
        Function AddWhere() As IQuery
    End Interface
    
    Public Interface IUpdate : Inherits IQuery
        Overloads Function AddWhere() As IUpdate
    End Interface
    
    Public Interface ISelect : Inherits IQuery
        Overloads Function AddWhere() As ISelect
        Function AddGroupBy() As ISelect
    End Interface
    
    Public Class QueryBase : Implements IQuery
        Public Function AddWhere() As IQuery Implements IQuery.AddWhere
            ''...
            Return Me
        End Function
    End Class
    
    Public Class UpdateQuery : Inherits QueryBase : Implements IUpdate
        Public Shadows Function AddWhere() As IUpdate Implements IUpdate.AddWhere
            MyBase.AddWhere()
            Return Me
        End Function
    End Class
    
    Public Class SelectQuery : Inherits QueryBase : Implements ISelect
        Public Shadows Function AddWhere() As ISelect Implements ISelect.AddWhere
            MyBase.AddWhere()
            Return Me
        End Function
        Public Function AddGroupBy() As ISelect Implements ISelect.AddGroupBy
            ''...
            Return Me
        End Function
    End Class
