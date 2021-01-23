    @{Html.Kendo().Grid(Model)
        .Name("AuditGrid")
        .DetailTemplate(auditrec =>
        {
            @<text>
            @{@Html.Telerik()
                 .Grid(auditrec.Details)
                 .Name("Detail_" + auditrec.ID.ToString()}
            )
            </text>
        })}
