    <div style="height:270px" >
        <table>
            <tr>
                <td width="100%"> 
                    <br />
         
                    @(Html.Telerik().Grid<FamilyParameter>()
                          .Name("GridParam")
                          .DataKeys(keys => keys.Add(param => param.Code))
                          .HtmlAttributes(new { style = "width: 420px;" })
                          .NoRecordsTemplate("No existen resultados...")
                          .DataBinding(
                              dataBinding => dataBinding.Ajax()
                                                 .Select("_EditMaterial_SelectParameters", Controllers.Valoration,Model)
                                                 .Update("_EditMaterial_UpdateParameters", Controllers.Valoration,Model)
                          )
                          .Columns(columns =>
                              {
                                  columns.Bound(param => param.Code).Width("75px").HtmlAttributes(new { style = "text-align: left;" }).ReadOnly();
                                  columns.Bound(param => param.Description).Width("200px").HtmlAttributes(new { style = "text-align: left;" }).ReadOnly();
                                  columns.Bound(param => param.Value).Width("65px").HtmlAttributes(new { style = "text-align: left;" });
                                  columns.Command(commands =>
                                                  commands.Edit().ButtonType(GridButtonType.Image)
                                      ).Width(60);
                              })
                          .Editable(editing => editing.Mode(GridEditMode.InLine))
                          .Scrollable(scrolling => scrolling.Height(140))
                          .Footer(false)
                          .Sortable()
                                  .ClientEvents(e => e.OnEdit("OnEditGridParam"))
                          .Resizable(resizing => resizing.Columns(true))
                          .Reorderable(reorder => reorder.Columns(true))
                          )
                    
                </td>
            </tr>
        </table>
    </div>
    
    <script type="text/javascript">
    
        function OnEditGridParam(e) {
            var item = { id: e.dataItem.Code };
            $.ajax({
                url: "/Valoration/_EditMaterial_EditParameters",
                type: "POST",
                async: false,
                data: item,
                success: function (data, status, xhr) {
                  
                    $.post(data.familyParameterValueView, item, function (partial) { $('#divFamilyParameterValue').html(partial); });   
          
                },
                error: function (xhr, status, err) {
                    alert(err);
                }
            }); 
    
    
        }
    
    </script>
