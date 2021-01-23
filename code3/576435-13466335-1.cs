    Partial Class controls_Sample
    Inherits BaseUC
    Public Overrides Property lblPageTitle As System.Web.UI.WebControls.Label
        Get
            Return title
        End Get
        Set(value As System.Web.UI.WebControls.Label)
            title = value
        End Set
    End Property
    End Class
