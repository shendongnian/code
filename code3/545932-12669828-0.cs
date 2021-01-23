       <tr>
                    <td>
                        <label>
                            Owner</label>
                    </td>
                    <td>
                        @Html.DropDownListFor(m => m.OwnerId, new System.Web.Mvc.SelectList(Model.CallForPaperJournalOwnersList, "OwnerId", "Owner"), new { id = "btnsave2" })
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            Journal Code:</label>
                    </td>
                    <td>
                        @Html.DropDownListFor(m => m.JournalCode, new System.Web.Mvc.SelectList(Model.JournalsWithCallForPaperHtmlList, "JournalCode", "JournalCode"), new { id= "btnchange2" })
    
                    </td>
                </tr>
