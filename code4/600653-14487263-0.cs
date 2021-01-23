    @(Html.Kendo().Grid(Model)
      .Name("grdDocumentManager")
      //Column Binding
      .Columns(columns =>
                   {
                       columns.Bound(dm => dm.DocumentNote).Title("Note").Width("20px").ClientTemplate("#if(trim(DocumentNote) != \"\"){#" +
                                                        "<img src=\"/content/i_discuss.gif\" title=\"View Notes\" onclick=\"javascript:showWindow(#=DocumentId#, '#=CaseId#');\" width=\"16\" height=\"16\" border=\"0\" style=\"cursor:pointer;\">#}" +
                                                    "else{#" +
                                                        "<img src=\"/content/i_rate.gif\" title=\"Add Note\" onclick=\"javascript:showWindow(#=DocumentId#, '#=CaseId#');\" width=\"16\" height=\"16\" border=\"0\" style=\"cursor:pointer;\">" +
                                                    "#}#");
                       columns.Bound(dm => dm.DocumentId).Hidden(true);
                       columns.Bound(dm => dm.CaseId).Width("50px");
                       columns.Bound(dm => dm.PresidingJudge).ClientGroupHeaderTemplate("Presiding Judge: #=value#").Width("20px");
                       columns.Bound(dm => dm.MagistrateJudge).ClientGroupHeaderTemplate("Magistrate Judge: #=value#").Width("20px");
                       columns.Bound(dm => dm.CaseType).Width("20px");
                       columns.Bound(dm => dm.StatusValue).Width("20px").ClientTemplate("#=Status#").EditorTemplateName("StatusEditor").Title("Status");
                       columns.Bound(dm => dm.UserName).Width("20px").EditorTemplateName("UserNameEditor");
                       columns.Bound(dm => dm.CreationDate).Width("50px").Format("{0:g}");
                       columns.Bound(dm => dm.PageCount).Width("20px");
                       columns.Command(command => command.Edit()).Width(200);
                   }
      )
      .Editable(e => e.Mode(GridEditMode.InLine))
      .DataSource(ds => ds.Ajax()
                        .Model(m => {
                                        m.Id(dm => dm.DocumentId);
                                        m.Field(dm => dm.CaseId).Editable(false);
                                        m.Field(dm => dm.CaseType).Editable(false);
                                        m.Field(dm => dm.CreationDate).Editable(false);
                                        m.Field(dm => dm.DocumentNote).Editable(false);
                                        m.Field(dm => dm.MagistrateJudge).Editable(false);
                                        m.Field(dm => dm.PresidingJudge).Editable(false);
                                        m.Field(dm => dm.PageCount).Editable(false);
                            
                        })
                        .Update(update => update.Action("DocumentUpdate","Admin"))
                        
                        
                 )
      )
