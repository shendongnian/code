    grid.Column(
        columnName: "ID", 
        header: "ID", 
        canSort: true, 
        format: item => Html.ActionLink(
            ((int)item.ID).ToString(), 
            "DetailsRequest", 
            "CRM", 
            new { ID = item.ID }, 
            null
        )
    )
